namespace coveo2014.Controllers
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;

    using coveo2014.Domain;
    using coveo2014.Models;
    using coveo2014.Services;

    public class HomeController : Controller
    {
        private readonly IDataProvider dataProvider;

        private readonly IIndex index;

        public HomeController(IDataProvider dataProvider, IIndex index)
        {
            this.dataProvider = dataProvider;
            this.index = index;
            this.dataProvider.CrawlData();
        }

        public string Start()
        {
            this.index.Start();
            return "Yay!";
        }

        public ActionResult Index()
        {
            //var socket = new TSocket("ec2-54-209-188-85.compute-1.amazonaws.com", 9090);
            //var binaryProtocol = new TBinaryProtocol(socket);

            //var client = new Indexer.Client(binaryProtocol);
            //socket.Open();

            //client.ping

            var model = new PageModel<Genre>();

            model.AvailableFacets.Add(
                new Facet { IsList = true, Name = "Pays", Values = new[] { "Canada", "USA", "UK" } });

            model.AvailableFacets.Add(
                new Facet
                {
                    IsList = false,
                    Name = "Nombre de disque",
                    Values =
                        Enumerable.Range(0, 20).Select(x => x.ToString(CultureInfo.InvariantCulture)).ToList()
                });

            var genres = new List<Genre>();

            foreach (var genre in this.dataProvider.Genres)
            {

                var albums =
                    this.dataProvider.Albums.Where(x => x.Value.Genres.Select(y => y.Trim()).Contains(genre)).Take(16).Select(x => x.Value).ToList();

                var map = new Dictionary<string, string>();

                foreach (var album in albums.Where(x => x.ArtistsId.Count > 0).Take(4))
                {
                    map.Add(album.Name, this.dataProvider.Artists[album.ArtistsId.First()].Name);
                }

                genres.Add(new Genre
                           {
                               Name = genre,
                               AlbumArtist = map
                           });
            }

            model.Items = genres;

            return this.View(model);
        }

        public ActionResult Genres(string genre)
        {
            var model = new PageModel<KeyValuePair<Artist, IList<Album>>>();

            model.AvailableFacets.Add(
                new Facet { IsList = true, Name = "Pays", Values = new[] { "Canada", "USA", "UK" } });

            model.AvailableFacets.Add(
                new Facet
                {
                    IsList = false,
                    Name = "Nombre de disque",
                    Values =
                        Enumerable.Range(0, 20).Select(x => x.ToString(CultureInfo.InvariantCulture)).ToList()
                });

            var artists =
                    this.dataProvider.Artists.Where(x => x.Value.Genres.Select(y => y.Trim()).Contains(genre)).Select(x => x.Value).ToList();

            foreach (var artist in artists)
            {
                
                var albums = artist.AlbumsId.Where(this.dataProvider.Albums.ContainsKey).Select(x => this.dataProvider.Albums[x]).ToList();

                var dic = new KeyValuePair<Artist, IList<Album>>(artist, albums);

                model.Items.Add(dic);
            }

            return View(model);
        }

        public ActionResult Artist(string id)
        {
            var model = new PageModel<KeyValuePair<Artist, IList<Album>>>();

            model.AvailableFacets.Add(
               new Facet { IsList = true, Name = "Pays", Values = new[] { "Canada", "USA", "UK" } });

            model.AvailableFacets.Add(
                new Facet
                {
                    IsList = false,
                    Name = "Nombre de disque",
                    Values =
                        Enumerable.Range(0, 20).Select(x => x.ToString(CultureInfo.InvariantCulture)).ToList()
                });

            var artist = this.dataProvider.Artists[id];

            var albums = artist.AlbumsId.Where(this.dataProvider.Albums.ContainsKey).Select(x => this.dataProvider.Albums[x]).ToList();

            var dic = new KeyValuePair<Artist, IList<Album>>(artist, albums);

            model.Items.Add(dic);

            return View(model);
        }

    }
}
