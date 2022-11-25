using DAL.Interfaces;
using DAL.Repositories;
using Ninject.Modules;

namespace BLL
{
    public class ServiceModule : NinjectModule
    {
        string connectionString;
        public ServiceModule(string connectionString) { this.connectionString = connectionString; }
        public override void Load()
        {
            Bind<IDataBaseRepository>().To<DataBaseRepositorySQL>().InSingletonScope().WithConstructorArgument(connectionString);
        }
    }
}
