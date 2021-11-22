using System;
using System.Collections.Generic;
using System.Text;

namespace LoanAgreementBusinessLogic.ViewModels
{
    public class ReportCostsViewModel
    {
        public string Counterpartylender { get; set; }

        public string LoanAgreement { get; set; }

        public string Date { get; set; }

        public decimal ProcentSum { get; set; }
    }
}
