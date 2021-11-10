using System;
using System.Collections.Generic;
using System.Text;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.Interfaces;
using LoanAgreementBusinessLogic.ViewModels;

namespace LoanAgreementBusinessLogic.BusinessLogic
{
    public class LoanAgreementLogic
    {
        private readonly ILoanAgreementStorage _loanAgreementStorage;

        public LoanAgreementLogic(ILoanAgreementStorage loanAgreementStorage)
        {
            _loanAgreementStorage = loanAgreementStorage;
        }

        public List<LoanAgreementViewModel> Read(LoanAgreementBindingModel model)
        {
            if (model == null)
            {
                return _loanAgreementStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<LoanAgreementViewModel> { _loanAgreementStorage.GetElement(model) };
            }
            return _loanAgreementStorage.GetFilteredList(model);
        }

        public int CreateOrUpdate(LoanAgreementBindingModel model)
        {
            var element = _loanAgreementStorage.GetElement(new LoanAgreementBindingModel
            {
                Id = model.Id
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такой договор займа");
            }
            if (model.Id.HasValue)
            {
                _loanAgreementStorage.Update(model);
                return model.Id.Value;
            }
            else
            {
                int Id = _loanAgreementStorage.Insert(model);
                return Id;
            }
        }

        public void Delete(LoanAgreementBindingModel model)
        {
            var element = _loanAgreementStorage.GetElement(new LoanAgreementBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Договора займа не найден");
            }
            _loanAgreementStorage.Delete(model);
        }
    }
}
