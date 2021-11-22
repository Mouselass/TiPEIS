using System;
using System.Collections.Generic;
using System.Text;

namespace LoanAgreementBusinessLogic.ViewModels
{
    public class ReportSumsViewModel
    {
        public string Counterpartylender { get; set; }

        public string Agent { get; set; }

        public decimal Sum { get; set; }

        public string Date { get; set; }
    }
}
