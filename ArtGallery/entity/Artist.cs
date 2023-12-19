using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.entity
{
    public class Artist
    {
        // Properties
        public int ArtistID { get; set; }  // Primary Key
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string Website { get; set; }
        public string ContactInformation { get; set; }

        // Constructors
        public Artist() { }
        public Artist(int artistID, string name, string biography, DateTime birthDate, string nationality, string website, string contactInformation)
        {
            ArtistID = artistID;
            Name = name;
            Biography = biography;
            BirthDate = birthDate;
            Nationality = nationality;
            Website = website;
            ContactInformation = contactInformation;
        }

        public override string ToString()
        {
            return $"ArtistID: {ArtistID}\nName: {Name}\nBiography: {Biography}\nBirthDate: {BirthDate}\nNationality: {Nationality}\nWebsite: {Website}\nContact: {ContactInformation}";
        }
    }
}
