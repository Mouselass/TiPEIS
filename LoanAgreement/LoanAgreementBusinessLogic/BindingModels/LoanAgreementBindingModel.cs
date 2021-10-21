using System;
using System.Collections.Generic;
using System.Text;

namespace LoanAgreementBusinessLogic.BindingModels
{
    public class LoanAgreementBindingModel
    {
        public int? Id { get; set; }

        public decimal Percent1 { get; set; }

        public decimal Percent2 { get; set; }

        public decimal Sumofloan { get; set; }

        public DateTime Dateofconclusion { get; set; }

        public DateTime Dateofmaturity { get; set; }

        public int? Counterpartylenderid { get; set; }

        public int? Agentid { get; set; }
    }
}
