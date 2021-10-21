using System;
using System.Collections.Generic;
using System.Text;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.ViewModels;

namespace LoanAgreementBusinessLogic.Interfaces
{
    public interface ICounterpartyLenderStorage
    {
        List<CounterpartyLenderViewModel> GetFullList();

        List<CounterpartyLenderViewModel> GetFilteredList(CounterpartyLenderBindingModel model);

        CounterpartyLenderViewModel GetElement(CounterpartyLenderBindingModel model);

        void Insert(CounterpartyLenderBindingModel model);

        void Update(CounterpartyLenderBindingModel model);

        void Delete(CounterpartyLenderBindingModel model);
    }
}
