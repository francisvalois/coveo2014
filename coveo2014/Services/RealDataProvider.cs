namespace coveo2014.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using coveo2014.Domain;

    public class RealDataProvider : IDataProvider
    {
        public RealDataProvider()
        {
            this.Albums = new Dictionary<string, Album>();
            this.Artists = new Dictionary<string, Artist>();
        }

        public IDictionary<string, Album> Albums { get; private set; }

        public IDictionary<string, Artist> Artists { get; private set; }

        public IList<string> Genres
        {
            get
            {
                return
                    this.Artists.SelectMany(x => x.Value.Genres.Select(y => y.Trim()))
                        .GroupBy(x => x)
                        .OrderByDescending(x => x.Count())
                        .Select(x => x.Key).ToList();
            }
        }

        public void CrawlData()
        {
        }
    }
}
