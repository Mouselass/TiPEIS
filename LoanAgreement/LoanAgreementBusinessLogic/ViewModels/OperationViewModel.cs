using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using LoanAgreementBusinessLogic.Enum;

namespace LoanAgreementBusinessLogic.ViewModels
{
    public class OperationViewModel
    {
        [DisplayName("Номер операции")]
        public int? Id { get; set; }

        public int? Loanagreementid { get; set; }

        [DisplayName("Договор")]
        public string Loanagreement { get; set; }

        [DisplayName("Тип операции")]
        public string Operationtype { get; set; }

        [DisplayName("Дата операции")]
        public DateTime Dateofoperation { get; set; }

        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
    }
}
