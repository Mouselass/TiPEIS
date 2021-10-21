using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace LoanAgreementBusinessLogic.ViewModels
{
    public class CounterpartyLenderViewModel
    {
        public int? Id { get; set; }

        [DisplayName("ФИО")]
        public string Fio { get; set; }
    }
}
