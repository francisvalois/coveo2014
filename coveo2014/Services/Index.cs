namespace coveo2014.Services
{
    using com.coveo.blitz.thrift;

    using Thrift.Server;
    using Thrift.Transport;

    public class Index : IIndex
    {
        private readonly Indexer.Iface indexer;

        private TSimpleServer server;

        public Index(Indexer.Iface indexer)
        {
            this.indexer = indexer;
        }

        public void Start()
        {
            var processor = new Indexer.Processor(this.indexer);
            var serverTransport = new TServerSocket(9090);
            server = new TSimpleServer(processor, serverTransport);
            server.Serve();
        }

        public void Stop()
        {
            if (server == null) return;
            server.Stop();
        }
    }
}
