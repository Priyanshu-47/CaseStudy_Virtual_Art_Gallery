using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Exceptions
{
    public class ArtWorkNotFoundException : Exception
    {
        public int ArtworkIdNotFound { get; }

        public ArtWorkNotFoundException() : base("Artwork not found.")
        {
        }

        public ArtWorkNotFoundException(int artworkId) : base($"Artwork with ID {artworkId} not found.")
        {
            ArtworkIdNotFound = artworkId;
        }

        public ArtWorkNotFoundException(string message) : base(message)
        {
        }

        public ArtWorkNotFoundException(string message, Exception ex) : base(message, ex)
        {
        }

        public ArtWorkNotFoundException(int artworkId, string message) : base(message)
        {
            ArtworkIdNotFound = artworkId;
        }
    }
}
