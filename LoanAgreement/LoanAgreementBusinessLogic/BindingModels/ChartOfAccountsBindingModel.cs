using System;
using System.Collections.Generic;
using System.Text;

namespace LoanAgreementBusinessLogic.BindingModels
{
    public class ChartOfAccountsBindingModel
    {
        public int? Id { get; set; }

        public string AccountNumber { get; set; }

        public string AccountName { get; set; }

        public string Subconto1 { get; set; }

        public string Subconto2 { get; set; }

        public string Subconto3 { get; set; }
    }
}
