namespace coveo2014.Services
{
    using System.Collections.Generic;

    using coveo2014.Domain;

    public interface IDataProvider
    {
        IDictionary<string, Album> Albums { get; }

        IDictionary<string, Artist> Artists { get; }

        IList<string> Genres { get; }

        void CrawlData();
    }
}
