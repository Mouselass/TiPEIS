using System;
using System.Collections.Generic;
using System.Text;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.Interfaces;
using LoanAgreementBusinessLogic.ViewModels;

namespace LoanAgreementBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IReportStorage _reportStorage;

        public ReportLogic(IReportStorage reportStorage)
        {
            _reportStorage = reportStorage;
        }

        public List<ReportSumsViewModel> GetSums(ReportBindingModel model)
        {
            return _reportStorage.GetSums(model);
        }

        public List<ReportCostsViewModel> GetCosts(ReportBindingModel model)
        {
            return _reportStorage.GetCosts(model);
        }

        public List<ReportPostingJournalViewModel> GetReportPostingJournals(ReportBindingModel model)
        {
            if (model == null || !model.DateFrom.HasValue || !model.DateTo.HasValue)
                return null;

            if (model.ChartOfAccount.HasValue)
                return new List<ReportPostingJournalViewModel> { _reportStorage.GetReportPostingJournal(model) };

            return _reportStorage.GetReportPostingJournals(model);
        }
    }
}
