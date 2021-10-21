using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LoanAgreementDatabase.Models
{
    public partial class Loanagreement
    {
        public Loanagreement()
        {
            Operation = new HashSet<Operation>();
        }

        public int Id { get; set; }
        public decimal Percent1 { get; set; }
        public decimal Percent2 { get; set; }
        public decimal Sumofloan { get; set; }
        public DateTime Dateofconclusion { get; set; }
        public DateTime Dateofmaturity { get; set; }
        public int Counterpartylenderid { get; set; }
        public int Agentid { get; set; }

        public virtual Agent Agent { get; set; }
        public virtual Counterpartylender Counterpartylender { get; set; }
        public virtual ICollection<Operation> Operation { get; set; }
    }
}
