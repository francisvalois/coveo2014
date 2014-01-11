namespace coveo2014.Domain
{
    using System;
    using System.Collections.Generic;

    public class Album
    {
        public IList<string> ArtistsId { get; set; }

        public string Id { get; set; }
        
        public IList<string> Genres { get; set; }
        
        public string Name { get; set; }
        
        public DateTime ReleaseDate { get; set; }
        
        public string Text { get; set; }
        
        public IList<string> TrackNames { get; set; }
    }
}
