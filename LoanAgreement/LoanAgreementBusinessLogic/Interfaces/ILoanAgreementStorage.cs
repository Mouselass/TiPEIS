using System;
using System.Collections.Generic;
using System.Text;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.ViewModels;

namespace LoanAgreementBusinessLogic.Interfaces
{
    public interface ILoanAgreementStorage
    {
        List<LoanAgreementViewModel> GetFullList();

        List<LoanAgreementViewModel> GetFilteredList(LoanAgreementBindingModel model);

        LoanAgreementViewModel GetElement(LoanAgreementBindingModel model);

        void Insert(LoanAgreementBindingModel model);

        void Update(LoanAgreementBindingModel model);

        void Delete(LoanAgreementBindingModel model);
    }
}
