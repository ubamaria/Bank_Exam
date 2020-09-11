using Bank_DAL.BindingModel;
using Bank_DAL.Interface;
using Bank_DAL.ViewModel;
using Bank_Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank_Database.Implement
{
    public class DepositLogic : IDepositLogic
    {
        public void CreateOrUpdate(DepositBindingModel model)
        {
            using (var context = new BankDatabase())
            {
                Deposit element = context.Deposits.FirstOrDefault(rec =>
               rec.ClientFIO == model.ClientFIO && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть вклад с таким именем");
                }
                if (model.Id.HasValue)
                {
                    element = context.Deposits.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Deposit();
                    context.Deposits.Add(element);
                }
                element.ClientFIO = model.ClientFIO;
                element.SizeDeposit = model.SizeDeposit;
                element.Email = model.Email;
                element.DateOpened = model.DateOpened;
                element.TypeValue = model.TypeValue;
                context.SaveChanges();
            }
        }
        public void Delete(DepositBindingModel model)
        {
            using (var context = new BankDatabase())
            {
                Deposit element = context.Deposits.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Deposits.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<DepositViewModel> Read(DepositBindingModel model)
        {
            using (var context = new BankDatabase())
            {
                return context.Deposits
                .Where(rec => model == null || rec.Id == model.Id || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.Bank.DateCreate >= model.DateFrom && rec.Bank.DateCreate <= model.DateTo))
                .Select(rec => new DepositViewModel
                {
                    Id = rec.Id,
                    ClientFIO = rec.ClientFIO,
                    Email = rec.Email,
                    BankId = rec.BankId,
                    TypeValue = rec.TypeValue,
                    DateOpened = rec.Bank.DateCreate,
                    Name = rec.Bank.Name,
                })
                .ToList();
            }
        }
    }
}
