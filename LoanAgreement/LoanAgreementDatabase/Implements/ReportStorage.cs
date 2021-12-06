using System;
using System.Collections.Generic;
using System.Linq;
using LoanAgreementBusinessLogic.Interfaces;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.ViewModels;
using LoanAgreementBusinessLogic.Enum;
using Microsoft.EntityFrameworkCore;

namespace LoanAgreementDatabase.Implements
{
    public class ReportStorage : IReportStorage
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

        public ReportPostingJournalViewModel GetReportPostingJournal(ReportBindingModel model)
        {
            using (var context = new postgresContext())
            {
                var startBalance = context.Postingjournal.Include(rec => rec.Operation).Where(rec => rec.Date < model.DateFrom.Value &&
                    (rec.Debitaccount == model.ChartOfAccount || rec.Creditaccount == model.ChartOfAccount)).ToList();

                var periodBalance = context.Postingjournal.Include(rec => rec.Operation).Where(rec => rec.Date >= model.DateFrom.Value &&
                    (rec.Debitaccount == model.ChartOfAccount || rec.Creditaccount == model.ChartOfAccount)).ToList();

                var reportPostingJournalViewModel = new ReportPostingJournalViewModel
                {
                    ChartOfAccountsId = model.ChartOfAccount.Value,
                    ChartOfAccounts = model.ChartOfAccountName,
                    BalanceStartPeriodDebit = startBalance.Where(rec => rec.Debitaccount == model.ChartOfAccount).Sum(rec => rec.Operation.Sum),
                    BalanceStartPeriodCredit = startBalance.Where(rec => rec.Creditaccount == model.ChartOfAccount).Sum(rec => rec.Operation.Sum),
                    BalancePeriodDebit = periodBalance.Where(rec => rec.Debitaccount == model.ChartOfAccount).Sum(rec => rec.Operation.Sum),
                    BalancePeriodCredit = periodBalance.Where(rec => rec.Creditaccount == model.ChartOfAccount).Sum(rec => rec.Operation.Sum)
                };
                
                switch (reportPostingJournalViewModel.ChartOfAccounts)
                {
                    case "51":
                        reportPostingJournalViewModel.BalanceStartPeriodDebit -= reportPostingJournalViewModel.BalanceStartPeriodCredit;
                        reportPostingJournalViewModel.BalanceStartPeriodCredit = 0;
                        reportPostingJournalViewModel.BalancePeriodDebit -= reportPostingJournalViewModel.BalancePeriodCredit;
                        reportPostingJournalViewModel.BalancePeriodCredit = 0;
                        break;
                    case "67":
                        reportPostingJournalViewModel.BalanceStartPeriodCredit -= reportPostingJournalViewModel.BalanceStartPeriodDebit;
                        reportPostingJournalViewModel.BalanceStartPeriodDebit = 0;
                        reportPostingJournalViewModel.BalancePeriodCredit -= reportPostingJournalViewModel.BalancePeriodDebit;
                        reportPostingJournalViewModel.BalancePeriodDebit = 0;                        
                        break;
                }

                reportPostingJournalViewModel.BalanceEndPeriodDebit = reportPostingJournalViewModel.BalanceStartPeriodDebit + reportPostingJournalViewModel.BalancePeriodDebit;
                reportPostingJournalViewModel.BalanceEndPeriodCredit = reportPostingJournalViewModel.BalanceStartPeriodCredit + reportPostingJournalViewModel.BalancePeriodCredit;

                return reportPostingJournalViewModel;
            }
        }

        public List<ReportPostingJournalViewModel> GetReportPostingJournals(ReportBindingModel model)
        {
            using (var context = new postgresContext())
            {
                var chartOfAccounts = context.Chartofaccounts.ToList();

                var result = new List<ReportPostingJournalViewModel>();

                foreach (var chartOfAccount in chartOfAccounts)
                {
                    model.ChartOfAccount = chartOfAccount.Id;
                    model.ChartOfAccountName = chartOfAccount.Accountnumber.ToString();
                    result.Add(GetReportPostingJournal(model));
                }

                return result;
            }
        }
    }
}
