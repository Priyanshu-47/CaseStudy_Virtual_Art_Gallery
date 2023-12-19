using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.entity
{
    public class Users
    {
        public int UserId { get; set; }     //Primary Key
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfilePicture { get; set; }
        public List<FavoriteArtwork> favoriteArtworks { get; set; }    // List of references to ArtworkIDs


        public Users() { }
        public Users(int userId, string userName, string password, string email, string firstName, string lastName, DateTime dateOfBirth, string profilePicture, List<FavoriteArtwork> favoriteArtworks)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            ProfilePicture = profilePicture;
            this.favoriteArtworks = favoriteArtworks;
        }

        public override string ToString()
        {
            return $"userId \t\t:\t{UserId}\nUserName \t:\t{UserName}\nEmail \t\t:\t{Email}\nFirstName \t:\t{FirstName}\nLastName \t:\t{LastName}\nDateOfBirth \t:\t{DateOfBirth}\nProfilePicture \t:\t{ProfilePicture}";
        }

    }
}
