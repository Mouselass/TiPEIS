using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace LoanAgreementBusinessLogic.ViewModels
{
    public class AgentViewModel
    {
        public int? Id { get; set; }

        [DisplayName("ФИО")]
        public string Fio { get; set; }

        [DisplayName("Должность")]
        public string Post { get; set; }
    }
}
