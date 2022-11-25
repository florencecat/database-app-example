using Ninject.Modules;
using BLL.Interfaces;
using BLL.Services;
using BLL;

namespace Lab3
{
    public class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataBaseCRUD>().To<DataBaseOperations>();
            Bind<IReportService>().To<ReportService>();
            Bind<IEventService>().To<EventService>();
        }
    }
}
