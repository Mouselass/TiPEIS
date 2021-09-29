using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LoanAgreementDatabase.Models
{
    public partial class Chartofaccounts
    {
        public Chartofaccounts()
        {
            PostingjournalCreditaccountNavigation = new HashSet<Postingjournal>();
            PostingjournalDebitaccountNavigation = new HashSet<Postingjournal>();
        }

        public int Id { get; set; }
        public int Accountnumber { get; set; }
        public string Accountname { get; set; }
        public string Subconto1 { get; set; }
        public string Subconto2 { get; set; }
        public string Subconto3 { get; set; }

        public virtual ICollection<Postingjournal> PostingjournalCreditaccountNavigation { get; set; }
        public virtual ICollection<Postingjournal> PostingjournalDebitaccountNavigation { get; set; }
    }
}
