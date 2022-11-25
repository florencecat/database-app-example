using System;
using BLL.Interfaces;
using BLL;
using System.Windows.Forms;
using Ninject;

namespace Lab3
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            StandardKernel kernel = new StandardKernel(new NinjectRegistration(), new ServiceModule("EventContext")); // Инициализация ядра Ninject

            // Внедрение зависимостей
            IDataBaseCRUD dataBaseCRUD = kernel.Get<IDataBaseCRUD>();
            IEventService eventService = kernel.Get<IEventService>();
            IReportService reportService = kernel.Get<IReportService>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(dataBaseCRUD, eventService, reportService));
        }
    }
}
