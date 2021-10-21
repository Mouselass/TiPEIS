using System;
using System.Collections.Generic;
using System.Linq;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.Interfaces;
using LoanAgreementBusinessLogic.ViewModels;
using LoanAgreementDatabase.Models;

namespace LoanAgreementDatabase.Implements
{
    public class AgentStorage : IAgentStorage
    {
        public List<AgentViewModel> GetFullList()
        {
            using (var context = new postgresContext())
            {
                return context.Agent.Select(rec => new AgentViewModel
                {
                    Id = rec.Id,
                    Fio = rec.Fio,
                    Post = rec.Post
                })
                .ToList();
            }
        }

        public List<AgentViewModel> GetFilteredList(AgentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                return context.Agent.Select(rec => new AgentViewModel
                {
                    Id = rec.Id,
                    Fio = rec.Fio,
                    Post = rec.Post
                })
                .ToList();
            }
        }

        public AgentViewModel GetElement(AgentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                var agent = context.Agent.FirstOrDefault(rec => rec.Id == model.Id);
                return agent != null ?
                new AgentViewModel
                {
                    Id = agent.Id,
                    Fio = agent.Fio,
                    Post = agent.Post
                } :
                null;
            }
        }

        public void Insert(AgentBindingModel model)
        {
            using (var context = new postgresContext())
            {
                context.Agent.Add(CreateModel(model, new Agent()));
                context.SaveChanges();
            }
        }

        public void Update(AgentBindingModel model)
        {
            using (var context = new postgresContext())
            {
                var element = context.Agent.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Агент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(AgentBindingModel model)
        {
            using (var context = new postgresContext())
            {
                Agent element = context.Agent.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Agent.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Контрагент-заимодавец не найден");
                }
            }
        }

        private Agent CreateModel(AgentBindingModel model, Agent agent)
        {
            agent.Fio = model.Fio;
            agent.Post = model.Post;
            return agent;
        }
    }
}
