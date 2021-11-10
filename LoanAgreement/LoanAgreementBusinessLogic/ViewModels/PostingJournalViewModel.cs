using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace LoanAgreementBusinessLogic.ViewModels
{
    public class PostingJournalViewModel
    {
        [DisplayName("Номер проводки")]
        public int? Id { get; set; }

        public int? Debitaccount { get; set; }

        [DisplayName("Счет дебета")]
        public int DebitaccountNumber { get; set; }

        [DisplayName("СубконтоДт1")]
        public string Subcontodebit1 { get; set; }

        [DisplayName("СубконтоДт2")]
        public string Subcontodebit2 { get; set; }

        [DisplayName("СубконтоДт3")]
        public string Subcontodebit3 { get; set; }

        public int? Creditaccount { get; set; }

        [DisplayName("Счет кредита")]
        public int CreditaccountNumber { get; set; }

        [DisplayName("СубконтоКт1")]
        public string Subcontocredit1 { get; set; }

        [DisplayName("СубконтоКт2")]
        public string Subcontocredit2 { get; set; }

        [DisplayName("СубконтоКт3")]
        public string Subcontocredit3 { get; set; }

        public int Amount { get; set; }

        [DisplayName("Сумма")]
        public decimal Sum { get; set; }

        [DisplayName("Номер операции")]
        public int? Operationid { get; set; }

        [DisplayName("Тип операции")]
        public string Operation { get; set; }

        public string Comment { get; set; }

        [DisplayName("Дата проводки")]
        public DateTime Date { get; set; }
    }
}
