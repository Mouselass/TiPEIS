using System;
using System.Collections.Generic;
using System.Text;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.ViewModels;

namespace LoanAgreementBusinessLogic.Interfaces
{
    public interface IPostingJournalStorage
    {
        List<PostingJournalViewModel> GetFullList();

        List<PostingJournalViewModel> GetFilteredList(PostingJournalBindingModel model);

        PostingJournalViewModel GetElement(PostingJournalBindingModel model);

        void Insert(PostingJournalBindingModel model);

        void Update(PostingJournalBindingModel model);

        void Delete(PostingJournalBindingModel model);
    }
}
