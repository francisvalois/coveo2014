namespace coveo2014.Architecture
{
    using com.coveo.blitz.thrift;

    using coveo2014.Services;

    using Ninject.Modules;

    public class BaseModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<Indexer.Iface>().To<RealIndex>().InSingletonScope();
            this.Kernel.Bind<IIndex>().To<Index>().InSingletonScope();
            this.Kernel.Bind<IDataProvider>().To<RealDataProvider>().InSingletonScope();
        }
    }
}
