using System.ComponentModel;

namespace LoanAgreementBusinessLogic.ViewModels
{
    public class ChartOfAccountsViewModel
    {
        public int? Id { get; set; }

        [DisplayName("Номер счета")]
        public string AccountNumber { get; set; }

        [DisplayName("Название счета")]
        public string AccountName { get; set; }

        [DisplayName("Субконто 1")]
        public string Subconto1 { get; set; }

        [DisplayName("Субконто 2")]
        public string Subconto2 { get; set; }

        [DisplayName("Субконто 3")]
        public string Subconto3 { get; set; }
    }
}
