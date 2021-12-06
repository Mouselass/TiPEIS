using System;
using System.Collections.Generic;
using System.Text;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.Interfaces;
using LoanAgreementBusinessLogic.ViewModels;

namespace LoanAgreementBusinessLogic.BusinessLogic
{
    public class UserLogic
    {
        private readonly IUserStorage _userStorage;

        public UserLogic(IUserStorage userStorage)
        {
            _userStorage = userStorage;
        }

        public List<UserViewModel> Read(UserBindingModel model)
        {
            if (model == null)
            {
                return _userStorage.GetFullList();
            }
            if (model.Login != null && model.Password != null)
            {
                return new List<UserViewModel> { _userStorage.GetElement(model) };
            }
            return _userStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(UserBindingModel model)
        {
            var element = _userStorage.GetElement(new UserBindingModel
            {
                Id = model.Id
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такой пользователь");
            }
            if (model.Id.HasValue)
            {
                _userStorage.Update(model);
            }
            else
            {
                _userStorage.Insert(model);
            }
        }

        public void Delete(UserBindingModel model)
        {
            var element = _userStorage.GetElement(new UserBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Пользователь не найден");
            }
            _userStorage.Delete(model);
        }
    }
}
