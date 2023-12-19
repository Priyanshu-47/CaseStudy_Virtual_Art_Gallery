using ArtGallery.entity;
using System.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallery.utility;

namespace ArtGallery.Services
{
    public class VirtualArtGalleryServices : IVirtualArtGalleryServices
    {
        public string connectionString;
        SqlCommand cmd = null;

        public VirtualArtGalleryServices()
        {
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }



        public bool Login(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Query the database to find a user with the given username
                string query = "SELECT * FROM Users WHERE Username = @Username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // User with the given username found
                            string storedPassword = reader["Password"].ToString();

                            // Check if the retrieved password matches the provided password
                            if (storedPassword == password)
                            {
                                // Login successful
                                return true;
                            }
                        }
                    }
                }
            }

            // Login failed
            return false;
        }

        public bool Register(Users newUser)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    string insertQuery = "INSERT INTO Users (Username, Password, Email, FirstName, LastName, DateOfBirth) " +
                                         "VALUES (@Username, @Password, @Email, @FirstName, @LastName, @DateOfBirth)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {

                        command.Parameters.AddWithValue("@Username", newUser.UserName);
                        command.Parameters.AddWithValue("@Password", newUser.Password);
                        command.Parameters.AddWithValue("@Email", newUser.Email);
                        command.Parameters.AddWithValue("@FirstName", newUser.FirstName);
                        command.Parameters.AddWithValue("@LastName", newUser.LastName);
                        command.Parameters.AddWithValue("@DateOfBirth", newUser.DateOfBirth);


                        int rowsAffected = command.ExecuteNonQuery();



                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during database operation: {ex.Message}");
                return false;
            }
        }

        //public bool Register()
        //{
        //    Users newUser;
        //    try
        //    {
        //        Console.WriteLine("User Registration:");

        //        // Get user details
        //        Console.Write("Username: ");
        //        string username = Console.ReadLine();

        //        Console.Write("Password: ");
        //        string password = Console.ReadLine();

        //        Console.Write("Email: ");
        //        string email = Console.ReadLine();

        //        Console.Write("First Name: ");
        //        string firstName = Console.ReadLine();

        //        Console.Write("Last Name: ");
        //        string lastName = Console.ReadLine();

        //        Console.Write("Date of Birth (yyyy-MM-dd): ");
        //        DateTime dateOfBirth;
        //        while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
        //        {
        //            Console.WriteLine("Invalid date format. Please enter again (yyyy-MM-dd): ");
        //        }


        //        newUser = new Users
        //        {
        //            UserName = username,
        //            Password = password,
        //            Email = email,
        //            FirstName = firstName,
        //            LastName = lastName,
        //            DateOfBirth = dateOfBirth
        //        };


        //    }
        //    catch (FormatException ex)
        //    {
        //        Console.WriteLine($"Invalid input format: {ex.Message}");
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine($"An error occurred during registration: {ex.Message}");
        //        return false;
        //    }
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();


        //            string insertQuery = "INSERT INTO Users (Username, Password, Email, FirstName, LastName, DateOfBirth) " +
        //                                 "VALUES (@Username, @Password, @Email, @FirstName, @LastName, @DateOfBirth)";
        //            using (SqlCommand command = new SqlCommand(insertQuery, connection))
        //            {

        //                command.Parameters.AddWithValue("@Username", newUser.UserName);
        //                command.Parameters.AddWithValue("@Password", newUser.Password);
        //                command.Parameters.AddWithValue("@Email", newUser.Email);
        //                command.Parameters.AddWithValue("@FirstName", newUser.FirstName);
        //                command.Parameters.AddWithValue("@LastName", newUser.LastName);
        //                command.Parameters.AddWithValue("@DateOfBirth", newUser.DateOfBirth);


        //                int rowsAffected = command.ExecuteNonQuery();



        //                return rowsAffected > 0;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred during database operation: {ex.Message}");
        //        return false;
        //    }
        //}

        public List<Artwork> BrowseArtwork()
        {
            try
            {
                List<Artwork> artworks = new List<Artwork>();


                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    // Query to retrieve artworks
                    string query = "SELECT * FROM Artwork";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Create Artwork object from database record
                                Artwork artwork = new Artwork
                                {
                                    ArtworkID = Convert.ToInt32(reader["ArtworkID"]),
                                    Title = reader["Title"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    CreationDate = Convert.ToDateTime(reader["CreationDate"]),
                                    medium = reader["Medium"].ToString(),
                                    ImageURL = reader["ImageURL"].ToString(),
                                    artistID = Convert.ToInt32(reader["ArtistID"])
                                    // Add other properties as needed
                                };

                                artworks.Add(artwork);
                            }
                        }
                    }
                }

                return artworks;
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log the error)
                Console.WriteLine($"An error occurred while browsing artwork: {ex.Message}");
                return null;
            }
        }
        /*public List<Artwork> SearchArtwork(string keyword)
        {
            throw new NotImplementedException();
        }*/


        public List<Gallery> ViewGalleries()
        {
            try
            {
                List<Gallery> list = new List<Gallery>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Gallery";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Gallery temp = new Gallery
                                {
                                    GalleryId = Convert.ToInt32(reader["galleryId"]),
                                    Name = reader["name"].ToString(),
                                    Description = reader["description"].ToString(),
                                    Location = reader["location"].ToString(),
                                    CuratorID = Convert.ToInt32(reader["curatorId"]),
                                    OpeningHours = reader["openingHours"].ToString()
                                };
                                list.Add(temp);
                            }
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while browsing artwork: {ex.Message}");
                return null;
            }

        }

        public Users GetUserProfile(string username)
        {
            try
            {
                Users userProfile = null;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to retrieve user profile based on username
                    string query = "SELECT * FROM Users WHERE Username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Create Users object from database record
                                userProfile = new Users
                                {
                                    UserId = Convert.ToInt32(reader["UserID"]),
                                    UserName = reader["Username"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                    // Add other properties as needed
                                };
                            }
                        }
                    }
                }

                return userProfile;
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log the error)
                Console.WriteLine($"An error occurred while getting user profile: {ex.Message}");
                return null;
            }
        }


        public bool Logout()
        {
            try
            {
                Console.WriteLine("Logging out...");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during logout: {ex.Message}");
                return false;
            }
        }
    }
}


