namespace coveo2014.Services
{
    using System.Collections.Generic;

    using coveo2014.Domain;

    public interface IDataProvider
    {
        IList<string> Genres { get; }

        IList<Artist> Artists { get; }

        IList<Album> Albums { get; }

        void CrawlData();
    }
}
