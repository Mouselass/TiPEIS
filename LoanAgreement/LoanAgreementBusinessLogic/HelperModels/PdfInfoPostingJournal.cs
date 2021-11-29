using System;
using System.Collections.Generic;
using System.Text;
using LoanAgreementBusinessLogic.ViewModels;

namespace LoanAgreementBusinessLogic.HelperModels
{
    public class PdfInfoPostingJournal
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<ReportPostingJournalViewModel> PostingJournal { get; set; }
    }
}
