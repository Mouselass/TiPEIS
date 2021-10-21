using System;
using System.Collections.Generic;
using System.Text;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.ViewModels;

namespace LoanAgreementBusinessLogic.Interfaces
{
    public interface IAgentStorage
    {
        List<AgentViewModel> GetFullList();

        List<AgentViewModel> GetFilteredList(AgentBindingModel model);

        AgentViewModel GetElement(AgentBindingModel model);

        void Insert(AgentBindingModel model);

        void Update(AgentBindingModel model);

        void Delete(AgentBindingModel model);
    }
}
