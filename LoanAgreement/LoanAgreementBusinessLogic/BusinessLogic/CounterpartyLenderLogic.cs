using System;
using System.Collections.Generic;
using System.Text;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.Interfaces;
using LoanAgreementBusinessLogic.ViewModels;

namespace LoanAgreementBusinessLogic.BusinessLogic
{
    public class CounterpartyLenderLogic
    {
        private readonly ICounterpartyLenderStorage _counterpartyLenderStorage;

        public CounterpartyLenderLogic(ICounterpartyLenderStorage counterpartyLenderStorage)
        {
            _counterpartyLenderStorage = counterpartyLenderStorage;
        }

        public List<CounterpartyLenderViewModel> Read(CounterpartyLenderBindingModel model)
        {
            if (model == null)
            {
                return _counterpartyLenderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<CounterpartyLenderViewModel> { _counterpartyLenderStorage.GetElement(model) };
            }
            return _counterpartyLenderStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(CounterpartyLenderBindingModel model)
        {
            var element = _counterpartyLenderStorage.GetElement(new CounterpartyLenderBindingModel
            {
                Id = model.Id
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такой Контрагент-заимодавец");
            }
            if (model.Id.HasValue)
            {
                _counterpartyLenderStorage.Update(model);
            }
            else
            {
                _counterpartyLenderStorage.Insert(model);
            }
        }

        public void Delete(CounterpartyLenderBindingModel model)
        {
            var element = _counterpartyLenderStorage.GetElement(new CounterpartyLenderBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Контрагент-заимодавец не найден");
            }
            _counterpartyLenderStorage.Delete(model);
        }
    }
}
