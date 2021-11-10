using System;
using System.Collections.Generic;
using System.Text;

namespace LoanAgreementBusinessLogic.BindingModels
{
    public class PostingJournalBindingModel
    {
        public int? Id { get; set; }

        public int? Debitaccount { get; set; }

        public string Subcontodebit1 { get; set; }

        public string Subcontodebit2 { get; set; }

        public string Subcontodebit3 { get; set; }

        public int? Creditaccount { get; set; }

        public string Subcontocredit1 { get; set; }

        public string Subcontocredit2 { get; set; }

        public string Subcontocredit3 { get; set; }

        public int Amount { get; set; }

        public decimal Sum { get; set; }

        public int? Operationid { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public int? OperationIdReport { get; set; }
    }
}
