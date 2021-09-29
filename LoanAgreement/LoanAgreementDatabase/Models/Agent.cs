using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LoanAgreementDatabase.Models
{
    public partial class Agent
    {
        public Agent()
        {
            Loanagreement = new HashSet<Loanagreement>();
        }

        public int Id { get; set; }
        public string Fio { get; set; }
        public string Post { get; set; }

        public virtual ICollection<Loanagreement> Loanagreement { get; set; }
    }
}
