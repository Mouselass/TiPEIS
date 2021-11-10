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
    public class PostingJournalStorage : IPostingJournalStorage
    {
        public List<PostingJournalViewModel> GetFullList()
        {
            using (var context = new postgresContext())
            {
                return context.Postingjournal.Include(rec => rec.Operation).Include(rec => rec.DebitaccountNavigation)
                    .Include(rec => rec.CreditaccountNavigation).Select(rec => new PostingJournalViewModel
                {
                    Id = rec.Id,
                    Debitaccount = rec.Debitaccount,
                    DebitaccountNumber = rec.DebitaccountNavigation.Accountnumber,
                    Subcontodebit1 = rec.Subcontodebit1,
                    Subcontodebit2 = rec.Subcontodebit2,
                    Subcontodebit3 = rec.Subcontodebit3,
                    Creditaccount = rec.Creditaccount,
                    CreditaccountNumber = rec.CreditaccountNavigation.Accountnumber,
                    Subcontocredit1 = rec.Subcontocredit1,
                    Subcontocredit2 = rec.Subcontocredit2,
                    Subcontocredit3 = rec.Subcontocredit3,
                    Amount = rec.Amount,
                    Sum = rec.Sum,
                    Operationid = rec.Operationid,
                    Operation = rec.Operation.Operationtype,
                    Comment = rec.Comment,
                    Date = rec.Date
                })
                .ToList();
            }
        }

        public List<PostingJournalViewModel> GetFilteredList(PostingJournalBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                return context.Postingjournal.Include(rec => rec.Operation).Include(rec => rec.DebitaccountNavigation).Include(rec => rec.CreditaccountNavigation)
                    .Where(rec => (model.OperationIdReport.HasValue && rec.Operationid == model.OperationIdReport) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue && rec.Date.Date >= model.DateFrom.Value.Date && rec.Date.Date <= model.DateTo.Value.Date))
                .Select(rec => new PostingJournalViewModel
                {
                    Id = rec.Id,
                    Debitaccount = rec.Debitaccount,
                    DebitaccountNumber = rec.DebitaccountNavigation.Accountnumber,
                    Subcontodebit1 = rec.Subcontodebit1,
                    Subcontodebit2 = rec.Subcontodebit2,
                    Subcontodebit3 = rec.Subcontodebit3,
                    Creditaccount = rec.Creditaccount,
                    CreditaccountNumber = rec.CreditaccountNavigation.Accountnumber,
                    Subcontocredit1 = rec.Subcontocredit1,
                    Subcontocredit2 = rec.Subcontocredit2,
                    Subcontocredit3 = rec.Subcontocredit3,
                    Amount = rec.Amount,
                    Sum = rec.Sum,
                    Operationid = rec.Operationid,
                    Operation = rec.Operation.Operationtype,
                    Comment = rec.Comment,
                    Date = rec.Date
                })
                .ToList();
            }
        }

        public PostingJournalViewModel GetElement(PostingJournalBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                var postingJournal = context.Postingjournal.Include(rec => rec.Operation).Include(rec => rec.DebitaccountNavigation)
                    .Include(rec => rec.CreditaccountNavigation).FirstOrDefault(rec => (rec.Operationid == model.Operationid) || 
                    (rec.Operationid == model.Operationid && rec.Debitaccount == model.Debitaccount && rec.Creditaccount == model.Creditaccount));
                return postingJournal != null ?
                new PostingJournalViewModel
                {
                    Id = postingJournal.Id,
                    Debitaccount = postingJournal.Debitaccount,
                    DebitaccountNumber = postingJournal.DebitaccountNavigation.Accountnumber,
                    Subcontodebit1 = postingJournal.Subcontodebit1,
                    Subcontodebit2 = postingJournal.Subcontodebit2,
                    Subcontodebit3 = postingJournal.Subcontodebit3,
                    Creditaccount = postingJournal.Creditaccount,
                    CreditaccountNumber = postingJournal.CreditaccountNavigation.Accountnumber,
                    Subcontocredit1 = postingJournal.Subcontocredit1,
                    Subcontocredit2 = postingJournal.Subcontocredit2,
                    Subcontocredit3 = postingJournal.Subcontocredit3,
                    Amount = postingJournal.Amount,
                    Sum = postingJournal.Sum,
                    Operationid = postingJournal.Operationid,
                    Operation = postingJournal.Operation.Operationtype,
                    Comment = postingJournal.Comment,
                    Date = postingJournal.Date
                } :
                null;
            }
        }

        public void Insert(PostingJournalBindingModel model)
        {
            using (var context = new postgresContext())
            {
                context.Postingjournal.Add(CreateModel(model, new Postingjournal()));
                context.SaveChanges();
            }
        }

        public void Update(PostingJournalBindingModel model)
        {
            using (var context = new postgresContext())
            {
                var element = context.Postingjournal.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Проводка не найдена");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(PostingJournalBindingModel model)
        {
            using (var context = new postgresContext())
            {
                Postingjournal element = context.Postingjournal.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Postingjournal.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Проводка не найдена");
                }
            }
        }

        private Postingjournal CreateModel(PostingJournalBindingModel model, Postingjournal postingJournal)
        {
            postingJournal.Debitaccount = model.Debitaccount.Value;
            postingJournal.Subcontodebit1 = model.Subcontodebit1;
            postingJournal.Subcontodebit2 = model.Subcontodebit2;
            postingJournal.Subcontodebit3 = model.Subcontodebit3;
            postingJournal.Creditaccount = model.Creditaccount.Value;
            postingJournal.Subcontocredit1 = model.Subcontocredit1;
            postingJournal.Subcontocredit2 = model.Subcontocredit2;
            postingJournal.Subcontocredit3 = model.Subcontocredit3;
            postingJournal.Amount = model.Amount;
            postingJournal.Sum = model.Sum;
            postingJournal.Operationid = model.Operationid.Value;
            postingJournal.Comment = model.Comment;
            postingJournal.Date = model.Date;
            return postingJournal;
        }
    }
}
