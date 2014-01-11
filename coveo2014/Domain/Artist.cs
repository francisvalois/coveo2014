namespace coveo2014.Domain
{
    using System;
    using System.Collections.Generic;

    public class Artist
    {
        public IList<string> AlbumsId { get; set; }

        public DateTime EndDate { get; set; }

        public IList<string> Genres { get; set; }

        public IList<string> Groups { get; set; }

        public string Id { get; set; }

        public IList<string> Instruments { get; set; }

        public IList<string> Labels { get; set; }

        public string Name { get; set; }

        public string Pays { get; set; }

        public DateTime StartDate { get; set; }
    }
}
