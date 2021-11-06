using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace LoanAgreementBusinessLogic.ViewModels
{
    public class LoanAgreementViewModel
    {
        public int? Id { get; set; }

        public int? Counterpartylenderid { get; set; }

        public int? Agentid { get; set; }

        [DisplayName("Контрагент")]
        public string Counterpartylender { get; set; }

        [DisplayName("Агент")]
        public string Agent { get; set; }

        [DisplayName("Процент1")]
        public decimal Percent1 { get; set; }

        [DisplayName("Процент2")]
        public decimal Percent2 { get; set; }

        [DisplayName("Сумма")]
        public decimal Sumofloan { get; set; }

        public decimal? RemainingSumofloan { get; set; }

        [DisplayName("Дата заключения договора")]
        public DateTime Dateofconclusion { get; set; }

        [DisplayName("Дата истечения договора")]
        public DateTime Dateofmaturity { get; set; }
    }
}
