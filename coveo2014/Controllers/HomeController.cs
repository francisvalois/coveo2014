namespace coveo2014.Controllers
{
    using System.Web.Mvc;

    using coveo2014.Services;

    public class HomeController : Controller
    {
        private readonly IDataProvider dataProvider;

        public HomeController(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
            this.dataProvider.CrawlData();
        }

        public ActionResult Index()
        {
            //var socket = new TSocket("ec2-54-209-188-85.compute-1.amazonaws.com", 9090);
            //var binaryProtocol = new TBinaryProtocol(socket);

            //var client = new Indexer.Client(binaryProtocol);
            //socket.Open();

            //client.ping();

            return this.View(this.dataProvider.Genres);
        }
    }
}
