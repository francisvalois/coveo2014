namespace coveo2014.Controllers
{
    using System.Collections.Generic;
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
            var socket = new TSocket("ec2-54-209-188-85.compute-1.amazonaws.com", 9090);
            var binaryProtocol = new TBinaryProtocol(socket);

            var client = new Indexer.Client(binaryProtocol);
            socket.Open();
            client.ping();

            //var response = client.query(new Query
            //{
            //    FacetFilters = new List<FacetFilter>
            //                                        {
            //                                            new FacetFilter
            //                                            {
            //                                                MetadataName = "albums",
            //                                                Values = new List<string> {"get rich or die trying"}
            //                                            }
            //                                        }
            //});

            //foreach (var queryResult in response.Results)
            //{
            //    var arti = queryResult.Id;
            //}


            return this.View();
        }
    }
}
