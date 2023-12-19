using ArtGallery.entity;
using ArtGallery.Exceptions;
using ArtGallery.Services;
using ArtGallery.dao;
public class MainModule
{
    //IVirtualArtGalleryServices service = new VirtualArtGalleryServices();
    public static void Main(string[] args)
    {
        IVirtualArtGalleryServices service = new VirtualArtGalleryServices();
        MainModule obj = new MainModule();


        /*List<Artwork> artworkList = service.BrowseArtwork();
        foreach (Artwork artwork in artworkList )
        {
            Console.WriteLine(artwork);
            Console.WriteLine();
        }*/
        //service.BrowseArtwork();
        while (true)
        {
            Console.WriteLine("VIRTUAL ART GALLERY");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Please enter your choice : ");
            //Console.WriteLine("3. Browse Artwork");
            //Console.WriteLine("4. Search Artwork");
            //Console.WriteLine("5. View Galleries");
            //Console.WriteLine("6. User Profile");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    try
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Enter Username and Password");
                        string username = Console.ReadLine();
                        string password = Console.ReadLine();
                        bool LoginStatus = service.Login(username, password);
                        if (LoginStatus)
                        {
                            Console.WriteLine("Login SuccessFull");
                            obj.AfterLogin(username);
                        }
                        else
                        {
                            throw new UserNotFoundException();
                        }
                    }
                    catch (UserNotFoundException unf)
                    {
                        Console.WriteLine("User Not Found");
                        Console.WriteLine();
                    }
                    break;

                case "2":
                    Console.WriteLine("");
                    Users newuser = obj.GetUsersDetails();
                    bool RegistrationStatus = service.Register(newuser);
                    if (RegistrationStatus)
                        Console.WriteLine("Registration Successfull!!");
                    else
                        Console.WriteLine("Registration Failed");
                    break;

                case "3":
                    Console.WriteLine("Exiting the art gallery.");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number as displayed.");
                    break;
            }
        }

    }
    public Users GetUsersDetails()
    {
        Users newUser;
        try
        {
            Console.WriteLine("User Registration:");

            // Get user details
            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Date of Birth (yyyy-MM-dd): ");
            DateTime dateOfBirth;
            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
            {
                Console.WriteLine("Invalid date format. Please enter again (yyyy-MM-dd): ");
            }


            newUser = new Users
            {
                UserName = username,
                Password = password,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            };
            return newUser;

        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Invalid input format: {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {

            Console.WriteLine($"An error occurred during registration: {ex.Message}");
            return null;
        }

    }

    public void AfterLogin(string username)
    {
        IVirtualArtGalleryServices service = new VirtualArtGalleryServices();
        Console.WriteLine("-------Welcome to Virtual Art Gallary-------");
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Enter Your Choice");
            Console.WriteLine("1. Browse Artwork");
            Console.WriteLine("2. View Galleries");
            Console.WriteLine("3. View Your Profile");
            Console.WriteLine("4. Logout");
            Console.WriteLine();
            Console.WriteLine("Please enter your choice : ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    List<Artwork> artworkList = service.BrowseArtwork();
                    if (artworkList != null)
                    {
                        foreach (Artwork artwork in artworkList)
                        {
                            Console.WriteLine(artwork);
                            Console.WriteLine();
                        }
                    }
                    break;
                case "2":
                    List<Gallery> galleryList = service.ViewGalleries();
                    if (galleryList != null)
                    {
                        foreach (Gallery gallery in galleryList)
                        {
                            Console.WriteLine(gallery);
                            Console.WriteLine();
                        }
                    }
                    break;
                case "3":
                    Users userProfile = service.GetUserProfile(username);

                    if (userProfile != null)
                    {
                        Console.WriteLine(userProfile);
                    }
                    break;
                case "4":
                    if (service.Logout())
                    {
                        Console.WriteLine("Logout successful.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Logout failed. Please try again.");
                        break;
                    }
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }
        }
    }


    //public void AdminLogin(string username)
    //{
    //    IVirtualArtGallery admin = new VirtualArtGalleryDAO();
    //    Console.WriteLine();
    //    Console.WriteLine("Admin Login SuccessFull");
    //    Console.WriteLine("-------Welcome to Virtual Art Gallary-------");
    //    while (true)
    //    {
    //        Console.WriteLine();
    //        Console.WriteLine("Enter Your Choice");
    //        Console.WriteLine("1. Add Artwork");
    //        Console.WriteLine("2. Update Artwork");
    //        Console.WriteLine("3. Remove Artwork");
    //        Console.WriteLine("4. Get Artwork by Id");
    //        Console.WriteLine("5. Get User Favorite Artwork");
    //        Console.WriteLine("6. Browse Artwork");
    //        Console.WriteLine("7. View Galleries");
    //        Console.WriteLine("8. View Your Profile");
    //        Console.WriteLine("9. Logout");
    //        Console.WriteLine();
    //        Console.WriteLine("Please enter your choice : ");
    //        string choice = Console.ReadLine();
    //        switch (choice)
    //        {
    //            case "1":
    //                Artwork artwork1 = new Artwork();
    //                artwork1 = admin.ArtworkDetails();
    //                Console.WriteLine();
    //                bool status1 = admin.AddArtwork(artwork1);
    //                if (status1)
    //                    Console.WriteLine("ArtWork Added Successfull");
    //                else
    //                    Console.WriteLine("Artwork Not Added in the Database");
    //                break;
    //            case "2":
    //                try
    //                {
    //                    Artwork artwork2 = new Artwork();
    //                    Console.WriteLine("Enter artwork ID");
    //                    artwork2.ArtworkID = int.Parse(Console.ReadLine());
    //                    artwork2 = admin.ArtworkDetails();
    //                    bool status2 = admin.UpdateArtwork(artwork2);
    //                    if (status2)
    //                    {
    //                        Console.WriteLine("Artwork Update Successful");
    //                    }
    //                    else
    //                    {
    //                        Console.WriteLine("Artwork Update Failed");
    //                    }
    //                }
    //                catch (ArtWorkNotFoundException ex)
    //                {
    //                    Console.WriteLine($"Artwork not found: {ex.Message}");
    //                }
    //                break;
    //            case "3":
    //                Console.WriteLine();
    //                Console.WriteLine("Enter artwork ID to remove");
    //                int id3 = int.Parse(Console.ReadLine());
    //                bool status3 = admin.RemoveArtwork(id3);
    //                if (status3)
    //                {
    //                    Console.WriteLine("Artwork Removed");
    //                }
    //                else
    //                {
    //                    Console.WriteLine("Artwork Not Removed");
    //                }
    //                break;
    //            case "4":
    //                try
    //                {
    //                    Console.WriteLine();
    //                    Console.WriteLine("Enter Artwork Id");
    //                    int id4 = int.Parse(Console.ReadLine());
    //                    Artwork artwork4 = admin.GetArtworkByID(id4);
    //                    if (artwork4 != null)
    //                    {
    //                        Console.WriteLine(artwork4);
    //                    }
    //                    else
    //                        Console.WriteLine("Artwork Not Found");
    //                }
    //                catch (ArtWorkNotFoundException ex)
    //                {
    //                    //Console.WriteLine($"Artwork not found: {ex.Message}");
    //                }

    //                break;
    //            case "5":
    //                Console.WriteLine();
    //                List<Artwork> list = new List<Artwork>();
    //                Console.WriteLine("Enter User ID");
    //                int id5 = int.Parse(Console.ReadLine());
    //                list = admin.GetUserFavoriteArtworks(id5);
    //                if (list != null)
    //                {
    //                    foreach (Artwork art in list)
    //                    {
    //                        Console.WriteLine(art);
    //                        Console.WriteLine();
    //                    }
    //                }
    //                else
    //                    Console.WriteLine("Not Found");

    //                break;
    //            case "6":
    //                Console.WriteLine("ArtworkID Title                  Description                                   CreationDate       Medium                 ImageURL                                           ArtistID");
    //                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

    //                List<Artwork> artworkList = service.BrowseArtwork();
    //                if (artworkList != null)
    //                {
    //                    foreach (Artwork artwork in artworkList)
    //                    {
    //                        Console.WriteLine(artwork);
    //                        Console.WriteLine();
    //                    }
    //                }
    //                break;
    //            case "7":
    //                Console.WriteLine("GalleryId  Name                     Description                                  Location                        CuratorID    OpeningHours");
    //                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------");

    //                List<Gallery> galleryList = service.ViewGalleries();
    //                if (galleryList != null)
    //                {
    //                    foreach (Gallery gallery in galleryList)
    //                    {
    //                        Console.WriteLine(gallery);
    //                        Console.WriteLine();
    //                    }
    //                }
    //                break;
    //            case "8":
    //                Users userProfile = service.GetUserProfile(username);

    //                if (userProfile != null)
    //                {
    //                    Console.WriteLine(userProfile);
    //                }
    //                break;
    //            case "9":
    //                if (service.Logout())
    //                {
    //                    Console.WriteLine("Logout successful.");
    //                    return;
    //                }
    //                else
    //                {
    //                    Console.WriteLine("Logout failed. Please try again.");
    //                    break;
    //                }
    //            default:
    //                Console.WriteLine("Invalid choice. Please enter a number between 1 and 9.");
    //                break;
    //        }
    //    }
    //}

}