using System;
using System.Collections.Generic;
using System.Linq;
using LoanAgreementBusinessLogic.BindingModels;
using LoanAgreementBusinessLogic.Interfaces;
using LoanAgreementBusinessLogic.ViewModels;
using LoanAgreementBusinessLogic.Enum;
using LoanAgreementDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanAgreementDatabase.Implements
{
    public class OperationStorage : IOperationStorage
    {
        public List<OperationViewModel> GetFullList()
        {
            using (var context = new postgresContext())
            {
                return context.Operation.Include(rec => rec.Loanagreement).Select(rec => new OperationViewModel
                {
                    Id = rec.Id,
                    Loanagreementid = rec.Loanagreementid,
                    Loanagreement = ("Договор № " + rec.Loanagreement.Id + " от " + rec.Loanagreement.Dateofconclusion),
                    Operationtype = rec.Operationtype,
                    Dateofoperation = rec.Dateofoperation,
                    Sum = rec.Sum
                })
                .ToList();
            }
        }

        public List<OperationViewModel> GetFilteredList(OperationBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                return context.Operation.Include(rec => rec.Loanagreement).Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue && rec.Dateofoperation.Date >= model.DateFrom.Value.Date && rec.Dateofoperation.Date <= model.DateTo.Value.Date 
                    && !model.ReportLoanagreementid.HasValue) ||
                    (model.DateFrom.HasValue && model.DateTo.HasValue && rec.Dateofoperation.Date >= model.DateFrom.Value.Date && rec.Dateofoperation.Date <= model.DateTo.Value.Date
                    && model.ReportLoanagreementid.HasValue && model.ReportLoanagreementid == rec.Loanagreementid))
                .Select(rec => new OperationViewModel
                {
                    Id = rec.Id,
                    Loanagreementid = rec.Loanagreementid,
                    Loanagreement = ("Договор № " + rec.Loanagreement.Id + " от " + rec.Loanagreement.Dateofconclusion),
                    Operationtype = rec.Operationtype,
                    Dateofoperation = rec.Dateofoperation,
                    Sum = rec.Sum
                })
                .ToList();
            }
        }

        public OperationViewModel GetElement(OperationBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                var operation = context.Operation.Include(rec => rec.Loanagreement).FirstOrDefault(rec => rec.Loanagreementid == model.Loanagreementid && rec.Operationtype == model.Operationtype || rec.Id == model.Id);
                return operation != null ?
                new OperationViewModel
                {
                    Id = operation.Id,
                    Loanagreementid = operation.Loanagreementid,
                    Loanagreement = ("Договор № " + operation.Loanagreement.Id + " от " + operation.Loanagreement.Dateofconclusion),
                    Operationtype = operation.Operationtype,
                    Dateofoperation = operation.Dateofoperation,
                    Sum = operation.Sum
                } :
                null;
            }
        }

        public void Insert(OperationBindingModel model)
        {
            using (var context = new postgresContext())
            {
                context.Operation.Add(CreateModel(model, new Operation()));
                context.SaveChanges();
            }
        }

        public void Update(OperationBindingModel model)
        {
            using (var context = new postgresContext())
            {
                var element = context.Operation.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Операция не найдена");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(OperationBindingModel model)
        {
            using (var context = new postgresContext())
            {
                Operation element = context.Operation.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Operation.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Операция не найдена");
                }
            }
        }

        private Operation CreateModel(OperationBindingModel model, Operation operation)
        {
            operation.Loanagreementid = model.Loanagreementid.Value;
            operation.Operationtype = model.Operationtype;
            operation.Dateofoperation = model.Dateofoperation;
            operation.Sum = model.Sum;
            return operation;
        }
    }
}
