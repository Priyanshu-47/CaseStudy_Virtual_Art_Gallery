using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.entity
{
    public class Artwork
    {
        public int ArtworkID { get; set; }       //Primary Key
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string medium { get; set; }
        public string ImageURL { get; set; }
        public int artistID { get; set; }

        public Artwork()
        {
        }
        public Artwork(int artrworkid, string title, string disc, DateTime Cdate, string med, string IURl, int artistid)
        {
            ArtworkID = artrworkid;
            Title = title;
            Description = disc;
            CreationDate = Cdate;
            medium = med;
            ImageURL = IURl;
            artistID = artistid;
        }

        public override string ToString()
        {
            return $"ArtworkID \t:\t{ArtworkID}\nTitle \t\t:\t{Title}\nDescription \t:\t{Description}\nCreation Date \t:\t{CreationDate}\nMedium \t\t:\t{medium}\nImageURL \t:\t{ImageURL}\nArtistID \t:\t{artistID}";

        }
    }
}
