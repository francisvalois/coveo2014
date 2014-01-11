namespace coveo2014.Controllers
{
    using System.Web.Mvc;

    using com.coveo.blitz.thrift;

    using Thrift.Protocol;
    using Thrift.Transport;

    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var socket = new TSocket("ip", 2123);
            var binaryProtocol = new TBinaryProtocol(socket);

            var client = new Indexer.Client(binaryProtocol);

            return this.View();
        }
    }
}
