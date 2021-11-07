using System;
using System.Collections.Generic;
using System.Text;
using LoanAgreementBusinessLogic.Enum;

namespace LoanAgreementBusinessLogic.BindingModels
{
    public class OperationBindingModel
    {
        public int? Id { get; set; }

        public int? Loanagreementid { get; set; }

        public string Operationtype { get; set; }

        public DateTime Dateofoperation { get; set; }

        public decimal Sum { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public int? ReportLoanagreementid { get; set; }
    }
}
