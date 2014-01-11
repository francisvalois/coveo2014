namespace coveo2014.Domain
{
    using System.Collections.Generic;

    public class QueryResult
    {
        public IList<Album> Albums { get; set; }

        public IList<Artist> Artists { get; set; }
    }
}
