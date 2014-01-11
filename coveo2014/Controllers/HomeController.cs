namespace coveo2014.Controllers
{
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;

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

            var model = new PageModel<string>();

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

            model.Items = this.dataProvider.Genres;

            return this.View(model);
        }
    }
}
