using System;
using System.Collections.Generic;
using System.Text;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.ViewModels;

namespace LoanAgreementBusinessLogic.Interfaces
{
    public interface IReportStorage
    {
        List<ReportSumsViewModel> GetSums(ReportBindingModel model);

        List<ReportCostsViewModel> GetCosts(ReportBindingModel model);

        ReportPostingJournalViewModel GetReportPostingJournal(ReportBindingModel model);

        List<ReportPostingJournalViewModel> GetReportPostingJournals(ReportBindingModel model);
    }
}
