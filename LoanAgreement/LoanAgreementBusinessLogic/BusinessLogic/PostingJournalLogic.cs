using System;
using System.Collections.Generic;
using System.Text;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.Interfaces;
using LoanAgreementBusinessLogic.ViewModels;

namespace LoanAgreementBusinessLogic.BusinessLogic
{
    public class PostingJournalLogic
    {
        private readonly IPostingJournalStorage _postingJournalStorage;

        public PostingJournalLogic(IPostingJournalStorage postingJournalStorage)
        {
            _postingJournalStorage = postingJournalStorage;
        }

        public List<PostingJournalViewModel> Read(PostingJournalBindingModel model)
        {
            if (model == null)
            {
                return _postingJournalStorage.GetFullList();
            }
            if (model.Operationid.HasValue || (model.Operationid.HasValue && model.Debitaccount.HasValue && model.Creditaccount.HasValue))
            {
                return new List<PostingJournalViewModel> { _postingJournalStorage.GetElement(model) };
            }
            return _postingJournalStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(PostingJournalBindingModel model)
        {
            var element = _postingJournalStorage.GetElement(new PostingJournalBindingModel
            {
                Id = model.Id
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая проводка");
            }
            if (model.Id.HasValue)
            {
                _postingJournalStorage.Update(model);
            }
            else
            {
                _postingJournalStorage.Insert(model);
            }
        }

        public void Delete(PostingJournalBindingModel model)
        {
            var element = _postingJournalStorage.GetElement(new PostingJournalBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Проводка не найдена!");
            }
            _postingJournalStorage.Delete(model);
        }
    }
}
