using System;
using System.Collections.Generic;
using System.Text;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.ViewModels;

namespace LoanAgreementBusinessLogic.Interfaces
{
    public interface IOperationStorage
    {
        List<OperationViewModel> GetFullList();

        List<OperationViewModel> GetFilteredList(OperationBindingModel model);

        OperationViewModel GetElement(OperationBindingModel model);

        int Insert(OperationBindingModel model);

        void Update(OperationBindingModel model);

        void Delete(OperationBindingModel model);
    }
}
