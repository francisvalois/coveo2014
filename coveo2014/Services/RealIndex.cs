namespace coveo2014.Services
{
    using System;
    using System.Linq;

    using com.coveo.blitz.thrift;

    public class RealIndex : Indexer.Iface
    {
        private readonly IDataProvider dataProvider;

        public RealIndex(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public void indexAlbum(Album albumToIndex)
        {
            if (!dataProvider.Albums.ContainsKey(albumToIndex.Id))
            {
                dataProvider.Albums.Add(albumToIndex.Id, Convert(albumToIndex));    
            }
        }

        public void indexArtist(Artist artistToIndex)
        {
            if (!dataProvider.Albums.ContainsKey(artistToIndex.Id))
            {
                dataProvider.Artists.Add(artistToIndex.Id, Convert(artistToIndex));
            }
        }

        public void ping()
        {
        }

        public QueryResponse query(Query query)
        {
            return null;
        }

        public void reset()
        {
            
        }

        private static Domain.Album Convert(Album album)
        {
            var lol = new Domain.Album
            {
                Name = album.Name.First(),
                Id = album.Id,
                ArtistsId = album.Artists.ToList(),
                Genres = album.Genres.ToList(),
                Text = album.Text,
                TrackNames = album.Track_names.ToList(),
                ReleaseDate = SafeDateParse(album.Release_date.FirstOrDefault())
            };

            return lol;
        }

        private static Domain.Artist Convert(Artist artist)
        {
            try
            {
                return new Domain.Artist
                {
                    Name = artist.Name.First(),
                    AlbumsId = artist.Albums.ToList(),
                    EndDate = SafeDateParse(artist.Active_end.FirstOrDefault()),
                    StartDate = SafeDateParse(artist.Active_start.FirstOrDefault()),
                    Genres = artist.Genres.ToList(),
                    Groups = artist.Group_names.ToList(),
                    Id = artist.Id,
                    Instruments = artist.Instruments_played.ToList(),
                    Labels = artist.Labels.ToList(),
                    Pays = artist.Origin.FirstOrDefault(),
                    Text = artist.Text ?? string.Empty
                };
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private static DateTime SafeDateParse(string lol)
        {
            var d = new DateTime();
            DateTime.TryParse(lol, out d);

            return d;
        }

    }
}
