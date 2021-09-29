using System;
using System.Collections.Generic;
using System.Linq;
using LoanAgreementBusinessLogic;
using Microsoft.EntityFrameworkCore;
using LoanAgreementBusinessLogic.Interfaces;
using LoanAgreementBusinessLogic.ViewModels;
using LoanAgreementBusinessLogic.BindingModels;

namespace LoanAgreementDatabase
{
    public class ChartOfAccountsStorage : IChartOfAccountsStorage
    {
        public List<ChartOfAccountsViewModel> GetFullList()
        {
            using (var context = new postgresContext())
            {
                return context.Chartofaccounts.Select(rec => new ChartOfAccountsViewModel
                {
                    Id = rec.Id,
                    AccountName = rec.Accountname,
                    AccountNumber = rec.Accountnumber.ToString(),
                    Subconto1 = rec.Subconto1,
                    Subconto2 = rec.Subconto2,
                    Subconto3 = rec.Subconto3
                })
                .ToList();
            }
        }

        public List<ChartOfAccountsViewModel> GetFilteredList(ChartOfAccountsBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                return context.Chartofaccounts
                    .Where(rec => rec.Id == model.Id).Select(rec => new ChartOfAccountsViewModel
                    {
                        Id = rec.Id,
                        AccountName = rec.Accountname,
                        AccountNumber = rec.Accountnumber.ToString(),
                        Subconto1 = rec.Subconto1,
                        Subconto2 = rec.Subconto2,
                        Subconto3 = rec.Subconto3
                    })
                .ToList();
            }
        }

        public ChartOfAccountsViewModel GetElement(ChartOfAccountsBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                var chartOfAccounts = context.Chartofaccounts.FirstOrDefault(rec => rec.Id == model.Id);
                return chartOfAccounts != null ?
                new ChartOfAccountsViewModel
                {
                    Id = chartOfAccounts.Id,
                    AccountName = chartOfAccounts.Accountname,
                    AccountNumber = chartOfAccounts.Accountnumber.ToString(),
                    Subconto1 = chartOfAccounts.Subconto1,
                    Subconto2 = chartOfAccounts.Subconto2,
                    Subconto3 = chartOfAccounts.Subconto3
                } :
                null;
            }
        }
    }
}
