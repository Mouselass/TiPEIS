using System;
using System.Collections.Generic;
using System.Linq;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.Interfaces;
using LoanAgreementBusinessLogic.ViewModels;
using LoanAgreementDatabase.Models;

namespace LoanAgreementDatabase.Implements
{
    public class UserStorage : IUserStorage
    {
        public List<UserViewModel> GetFullList()
        {
            using (var context = new postgresContext())
            {
                return context.Users.Select(rec => new UserViewModel
                {
                    Id = rec.Id,
                    Login = rec.Login,
                    Password = rec.Password,
                    Role = rec.Role
                })
                .ToList();
            }
        }

        public List<UserViewModel> GetFilteredList(UserBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                return context.Users.Select(rec => new UserViewModel
                {
                    Id = rec.Id,
                    Login = rec.Login,
                    Password = rec.Password,
                    Role = rec.Role
                })
                .ToList();
            }
        }

        public UserViewModel GetElement(UserBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                var user = context.Users.FirstOrDefault(rec => rec.Login == model.Login && rec.Password == model.Password);
                return user != null ?
                new UserViewModel
                {
                    Id = user.Id,
                    Login = user.Login,
                    Password = user.Password,
                    Role = user.Role
                } :
                null;
            }
        }

        public void Insert(UserBindingModel model)
        {
            using (var context = new postgresContext())
            {
                context.Users.Add(CreateModel(model, new Users()));
                context.SaveChanges();
            }
        }

        public void Update(UserBindingModel model)
        {
            using (var context = new postgresContext())
            {
                var element = context.Users.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Пользователь не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(UserBindingModel model)
        {
            using (var context = new postgresContext())
            {
                Users element = context.Users.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Users.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Пользователь не найден");
                }
            }
        }

        private Users CreateModel(UserBindingModel model, Users user)
        {
            user.Login = model.Login;
            user.Password = model.Password;
            user.Role = model.Role;
            return user;
        }
    }
}
