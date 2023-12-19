using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.entity
{
    public class Gallery
    {
        public int GalleryId { get; set; }    //Primary Key
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int CuratorID { get; set; }    // Reference to ArtistID
        public string OpeningHours { get; set; }


        public Gallery() { }
        public Gallery(int galleryId, string name, string description,
                        string location, int curatorID, string openingHours)
        {
            GalleryId = galleryId;
            Name = name;
            Description = description;
            Location = location;
            CuratorID = curatorID;
            OpeningHours = openingHours;
        }

        public override string ToString()
        {
            return $"GalleryId \t:\t{GalleryId}\nName \t\t:\t{Name}\nDescription \t:\t{Description}\nLocation \t:\t{Location}\ncuratorID \t:\t{CuratorID}\nOpeningHours \t:\t{OpeningHours}";
        }

    }
}
