using LoanAgreementDatabase;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using LoanAgreementBusinessLogic.Interfaces;
using LoanAgreementBusinessLogic.BusinessLogic;
using LoanAgreementDatabase.Implements;

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
            currentContainer.RegisterType<ICounterpartyLenderStorage, CounterpartyLenderStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAgentStorage, AgentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ILoanAgreementStorage, LoanAgreementStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOperationStorage, OperationStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPostingJournalStorage, PostingJournalStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReportStorage, ReportStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ChartOfAccountsLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<CounterpartyLenderLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<AgentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<LoanAgreementLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<OperationLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<PostingJournalLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
