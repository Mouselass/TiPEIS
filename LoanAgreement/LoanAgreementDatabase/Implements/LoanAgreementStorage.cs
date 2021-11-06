using System;
using System.Collections.Generic;
using System.Linq;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.Interfaces;
using LoanAgreementBusinessLogic.ViewModels;
using LoanAgreementDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanAgreementDatabase.Implements
{
    public class LoanAgreementStorage : ILoanAgreementStorage
    {
        public List<LoanAgreementViewModel> GetFullList()
        {
            using (var context = new postgresContext())
            {
                return context.Loanagreement.Include(rec => rec.Agent).Include(rec => rec.Counterpartylender).Select(rec => new LoanAgreementViewModel
                {
                    Id = rec.Id,
                    Agentid = rec.Agentid,
                    Counterpartylenderid = rec.Counterpartylenderid,
                    Agent = rec.Agent.Fio,
                    Counterpartylender = rec.Counterpartylender.Fio,
                    Percent1 = rec.Percent1,
                    Percent2 = rec.Percent2,
                    Sumofloan = rec.Sumofloan,
                    RemainingSumofloan = rec.Remainingsumofloan,
                    Dateofconclusion = rec.Dateofconclusion,
                    Dateofmaturity = rec.Dateofmaturity
                })
                .ToList();
            }
        }

        public List<LoanAgreementViewModel> GetFilteredList(LoanAgreementBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                return context.Loanagreement.Include(rec => rec.Agent).Include(rec => rec.Counterpartylender).Select(rec => new LoanAgreementViewModel
                {
                    Id = rec.Id,
                    Agentid = rec.Agentid,
                    Counterpartylenderid = rec.Counterpartylenderid,
                    Agent = rec.Agent.Fio,
                    Counterpartylender = rec.Counterpartylender.Fio,
                    Percent1 = rec.Percent1,
                    Percent2 = rec.Percent2,
                    Sumofloan = rec.Sumofloan,
                    RemainingSumofloan = rec.Remainingsumofloan,
                    Dateofconclusion = rec.Dateofconclusion,
                    Dateofmaturity = rec.Dateofmaturity
                })
                .ToList();
            }
        }

        public LoanAgreementViewModel GetElement(LoanAgreementBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                var loanAgreement = context.Loanagreement.Include(rec => rec.Agent).Include(rec => rec.Counterpartylender).FirstOrDefault(rec => rec.Id == model.Id);
                return loanAgreement != null ?
                new LoanAgreementViewModel
                {
                    Id = loanAgreement.Id,
                    Agentid = loanAgreement.Agentid,
                    Counterpartylenderid = loanAgreement.Counterpartylenderid,
                    Agent = loanAgreement.Agent.Fio,
                    Counterpartylender = loanAgreement.Counterpartylender.Fio,
                    Percent1 = loanAgreement.Percent1,
                    Percent2 = loanAgreement.Percent2,
                    Sumofloan = loanAgreement.Sumofloan,
                    RemainingSumofloan = loanAgreement.Remainingsumofloan,
                    Dateofconclusion = loanAgreement.Dateofconclusion,
                    Dateofmaturity = loanAgreement.Dateofmaturity
                } :
                null;
            }
        }

        public void Insert(LoanAgreementBindingModel model)
        {
            using (var context = new postgresContext())
            {
                context.Loanagreement.Add(CreateModel(model, new Loanagreement()));
                context.SaveChanges();
            }
        }

        public void Update(LoanAgreementBindingModel model)
        {
            using (var context = new postgresContext())
            {
                var element = context.Loanagreement.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Договор займа не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(LoanAgreementBindingModel model)
        {
            using (var context = new postgresContext())
            {
                Loanagreement element = context.Loanagreement.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Loanagreement.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Договор займа не найден");
                }
            }
        }

        private Loanagreement CreateModel(LoanAgreementBindingModel model, Loanagreement loanAgreement)
        {
            loanAgreement.Agentid = model.Agentid.Value;
            loanAgreement.Counterpartylenderid = model.Counterpartylenderid.Value;
            loanAgreement.Percent1 = model.Percent1;
            loanAgreement.Percent2 = model.Percent2;
            loanAgreement.Sumofloan = model.Sumofloan;
            loanAgreement.Remainingsumofloan = Convert.ToDecimal(model.RemainingSumofloan);
            loanAgreement.Dateofconclusion = model.Dateofconclusion;
            loanAgreement.Dateofmaturity = model.Dateofmaturity;
            return loanAgreement;
        }
    }
}
