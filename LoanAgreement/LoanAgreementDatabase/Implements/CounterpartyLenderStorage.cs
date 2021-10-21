using System;
using System.Collections.Generic;
using System.Linq;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.Interfaces;
using LoanAgreementBusinessLogic.ViewModels;
using LoanAgreementDatabase.Models;

namespace LoanAgreementDatabase.Implements
{
    public class CounterpartyLenderStorage : ICounterpartyLenderStorage
    {
        public List<CounterpartyLenderViewModel> GetFullList()
        {
            using (var context = new postgresContext())
            {
                return context.Counterpartylender.Select(rec => new CounterpartyLenderViewModel
                {
                    Id = rec.Id,
                    Fio = rec.Fio
                })
                .ToList();
            }
        }

        public List<CounterpartyLenderViewModel> GetFilteredList(CounterpartyLenderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                return context.Counterpartylender.Select(rec => new CounterpartyLenderViewModel
                {
                    Id = rec.Id,
                    Fio = rec.Fio
                })
                .ToList();
            }
        }

        public CounterpartyLenderViewModel GetElement(CounterpartyLenderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                var counterpartyLender = context.Counterpartylender.FirstOrDefault(rec => rec.Id == model.Id);
                return counterpartyLender != null ?
                new CounterpartyLenderViewModel
                {
                    Id = counterpartyLender.Id,
                    Fio = counterpartyLender.Fio
                } :
                null;
            }
        }

        public void Insert(CounterpartyLenderBindingModel model)
        {
            using (var context = new postgresContext())
            {
                context.Counterpartylender.Add(CreateModel(model, new Counterpartylender()));
                context.SaveChanges();
            }
        }

        public void Update(CounterpartyLenderBindingModel model)
        {
            using (var context = new postgresContext())
            {
                var element = context.Counterpartylender.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Контрагент-заимодавец не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(CounterpartyLenderBindingModel model)
        {
            using (var context = new postgresContext())
            {
                Counterpartylender element = context.Counterpartylender.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Counterpartylender.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Контрагент-заимодавец не найден");
                }
            }
        }

        private Counterpartylender CreateModel(CounterpartyLenderBindingModel model, Counterpartylender counterpartyLender)
        {
            counterpartyLender.Fio = model.Fio;
            return counterpartyLender;
        }
    }
}
