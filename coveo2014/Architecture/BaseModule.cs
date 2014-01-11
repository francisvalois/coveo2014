namespace coveo2014.Architecture
{
    using coveo2014.Services;

    using Ninject.Modules;

    public class BaseModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<IDataProvider>().To<FakeDataProvider>().InSingletonScope();
        }
    }
}
