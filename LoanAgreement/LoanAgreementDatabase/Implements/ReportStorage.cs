using System;
using System.Collections.Generic;
using System.Linq;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.ViewModels;
using LoanAgreementBusinessLogic.Enum;
using Microsoft.EntityFrameworkCore;

namespace LoanAgreementDatabase.Implements
{
    public class ReportStorage
    { 
        public List<ReportSumsViewModel> GetSums(ReportBindingModel model)
        {
            using (var context = new postgresContext())
            {
                return context.Operation.Include(rec => rec.Loanagreement)
                    .Where(rec => rec.Dateofoperation.Date >= model.DateFrom.Value.Date && rec.Dateofoperation.Date <= model.DateTo.Value.Date && rec.Operationtype == OperationType.Заключение.ToString())
                .Select(rec => new ReportSumsViewModel
                {
                    Counterpartylender = rec.Loanagreement.Counterpartylender.Fio,
                    Agent = rec.Loanagreement.Agent.Fio,
                    Date = rec.Dateofoperation.ToShortDateString(),
                    Sum = rec.Sum
                })
                .ToList();
            }
        }

        public List<ReportCostsViewModel> GetCosts(ReportBindingModel model)
        {
            using (var context = new postgresContext())
            {
                return context.Postingjournal.Include(rec => rec.Operation).ThenInclude(rec => rec.Loanagreement)
                    .Where(rec => rec.Date.Date >= model.DateFrom.Value.Date && rec.Date.Date <= model.DateTo.Value.Date && rec.Debitaccount == 4)
                .Select(rec => new ReportCostsViewModel
                {
                    Counterpartylender = rec.Operation.Loanagreement.Counterpartylender.Fio,
                    LoanAgreement = "Договор №" + rec.Operation.Loanagreement.Id,
                    Date = $"C {rec.Operation.Loanagreement.Dateofconclusion.ToShortDateString()} по {rec.Operation.Loanagreement.Dateofmaturity.ToShortDateString()}",
                    ProcentSum = rec.Sum
                })
                .ToList();
            }
        }
    }
}
