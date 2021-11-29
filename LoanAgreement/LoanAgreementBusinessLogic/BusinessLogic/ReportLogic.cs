using System;
using System.Collections.Generic;
using System.Text;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.Interfaces;
using LoanAgreementBusinessLogic.ViewModels;
using LoanAgreementBusinessLogic.HelperModels;

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

        public void SaveCostsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDocCosts(new PdfInfoCosts
            {
                FileName = model.FileName,
                Title = "Ведомость расходов на получение займов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Costs = GetCosts(model)
            });
        }

        public void SaveSumsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDocSums(new PdfInfoSums
            {
                FileName = model.FileName,
                Title = "Ведомость сумм полученных займов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Sums = GetSums(model)
            });
        }

        public void SavePostingJournalToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDocPostingJournal(new PdfInfoPostingJournal
            {
                FileName = model.FileName,
                Title = "Оборотно-сальдовая ведомость",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                PostingJournal = GetReportPostingJournals(model)
            });
        }
    }
}
