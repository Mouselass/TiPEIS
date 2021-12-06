using System;
using System.Collections.Generic;
using System.Text;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.ViewModels;

namespace LoanAgreementBusinessLogic.Interfaces
{
    public interface IUserStorage
    {
        List<UserViewModel> GetFullList();

        List<UserViewModel> GetFilteredList(UserBindingModel model);

        UserViewModel GetElement(UserBindingModel model);

        void Insert(UserBindingModel model);

        void Update(UserBindingModel model);

        void Delete(UserBindingModel model);
    }
}
