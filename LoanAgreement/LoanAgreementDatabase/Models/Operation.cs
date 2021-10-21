using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LoanAgreementDatabase.Models
{
    public partial class Operation
    {
        public Operation()
        {
            Postingjournal = new HashSet<Postingjournal>();
        }

        public int Id { get; set; }
        public string Operationtype { get; set; }
        public DateTime Dateofoperation { get; set; }
        public decimal Sum { get; set; }
        public int Loanagreementid { get; set; }

        public virtual Loanagreement Loanagreement { get; set; }
        public virtual ICollection<Postingjournal> Postingjournal { get; set; }
    }
}
