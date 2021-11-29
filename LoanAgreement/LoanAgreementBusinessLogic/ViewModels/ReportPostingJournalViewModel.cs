using System;
using System.Collections.Generic;
using System.Text;

namespace LoanAgreementBusinessLogic.ViewModels
{
    public class ReportPostingJournalViewModel
    {
        public int? ChartOfAccountsId { get; set; }

        public string ChartOfAccounts { get; set; }

        public decimal BalanceStartPeriodDebit { get; set; }

        public decimal BalanceStartPeriodCredit { get; set; }

        public decimal BalancePeriodDebit { get; set; }

        public decimal BalancePeriodCredit { get; set; }

        public decimal BalanceEndPeriodDebit { get; set; }

        public decimal BalanceEndPeriodCredit { get; set; }
    }
}
