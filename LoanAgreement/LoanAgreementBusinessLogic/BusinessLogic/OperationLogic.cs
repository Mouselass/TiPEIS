using System;
using System.Collections.Generic;
using System.Text;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.Interfaces;
using LoanAgreementBusinessLogic.ViewModels;

namespace LoanAgreementBusinessLogic.BusinessLogic
{
    public class OperationLogic
    {
        private readonly IOperationStorage _operationStorage;

        public OperationLogic(IOperationStorage operationStorage)
        {
            _operationStorage = operationStorage;
        }

        public List<OperationViewModel> Read(OperationBindingModel model)
        {
            if (model == null)
            {
                return _operationStorage.GetFullList();
            }
            if (model.Loanagreementid.HasValue || model.Id.HasValue)
            {
                return new List<OperationViewModel> { _operationStorage.GetElement(model) };
            }
            return _operationStorage.GetFilteredList(model);
        }

        public int CreateOrUpdate(OperationBindingModel model)
        {
            var element = _operationStorage.GetElement(new OperationBindingModel
            {
                Id = model.Id
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая операция");
            }
            if (model.Id.HasValue)
            {
                _operationStorage.Update(model);
                return model.Id.Value;
            }
            else
            {
                int Id = _operationStorage.Insert(model);
                return Id;
            }
        }

        public void Delete(OperationBindingModel model)
        {
            var element = _operationStorage.GetElement(new OperationBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Операция не найдена!");
            }
            _operationStorage.Delete(model);
        }
    }
}
