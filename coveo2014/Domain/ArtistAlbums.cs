namespace coveo2014.Domain
{
    using System.Collections.Generic;

    public class ArtistAlbums
    {
        public IList<Album> Albums { get; set; }

        public Artist Artist { get; set; }
    }
}
