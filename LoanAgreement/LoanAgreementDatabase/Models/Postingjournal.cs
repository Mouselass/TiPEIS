using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LoanAgreementDatabase.Models
{
    public partial class Postingjournal
    {
        public int Id { get; set; }
        public int Debitaccount { get; set; }
        public string Subcontodebit1 { get; set; }
        public string Subcontodebit2 { get; set; }
        public string Subcontodebit3 { get; set; }
        public int Creditaccount { get; set; }
        public string Subcontocredit1 { get; set; }
        public string Subcontocredit2 { get; set; }
        public string Subcontocredit3 { get; set; }
        public int Amount { get; set; }
        public decimal Sum { get; set; }
        public int Operationid { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        public virtual Chartofaccounts CreditaccountNavigation { get; set; }
        public virtual Chartofaccounts DebitaccountNavigation { get; set; }
        public virtual Operation Operation { get; set; }
    }
}
