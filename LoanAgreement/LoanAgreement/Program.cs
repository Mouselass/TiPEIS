using LoanAgreementDatabase;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using LoanAgreementBusinessLogic.Interfaces;
using LoanAgreementBusinessLogic.BusinessLogic;

namespace LoanAgreement
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IChartOfAccountsStorage, ChartOfAccountsStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ChartOfAccountsLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
