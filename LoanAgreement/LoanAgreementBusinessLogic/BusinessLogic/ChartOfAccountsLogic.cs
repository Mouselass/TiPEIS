using System;
using System.Collections.Generic;
using LoanAgreementBusinessLogic.ViewModels;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.Interfaces;

namespace LoanAgreementBusinessLogic.BusinessLogic
{
    public class ChartOfAccountsLogic
    {
        private readonly IChartOfAccountsStorage _chartOfAccountsStorage;

        public ChartOfAccountsLogic(IChartOfAccountsStorage chartOfAccountsStorage)
        {
            _chartOfAccountsStorage = chartOfAccountsStorage;
        }

        public List<ChartOfAccountsViewModel> Read(ChartOfAccountsBindingModel model)
        {
            if (model == null)
            {
                return _chartOfAccountsStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ChartOfAccountsViewModel> { _chartOfAccountsStorage.GetElement(model) };
            }
            return _chartOfAccountsStorage.GetFilteredList(model);
        }
    }
}
