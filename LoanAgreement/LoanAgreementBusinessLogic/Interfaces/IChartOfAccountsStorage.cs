using System.Collections.Generic;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.ViewModels;

namespace LoanAgreementBusinessLogic.Interfaces
{
    public interface IChartOfAccountsStorage
    {
        List<ChartOfAccountsViewModel> GetFullList();

        List<ChartOfAccountsViewModel> GetFilteredList(ChartOfAccountsBindingModel model);

        ChartOfAccountsViewModel GetElement(ChartOfAccountsBindingModel model);
    }
}
