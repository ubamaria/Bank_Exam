using Bank_DAL.BindingModel;
using Bank_DAL.Interface;
using Bank_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_DAL.HelperModel
{
    public class ReportLogic
    {
        private readonly IBankLogic bank;
        private readonly IDepositLogic deposit;
        public ReportLogic(IBankLogic bank, IDepositLogic deposit)
        {
            this.bank = bank;
            this.deposit = deposit;
        }
        public List<DepositViewModel> GetDeposits(ReportBindingModel model)
        {
            var deposits = deposit.Read(new DepositBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            });
            var list = new List<DepositViewModel>();
            foreach (var serv in deposits)
            {
                var record = new DepositViewModel
                {
                    ClientFIO = serv.ClientFIO,
                    SizeDeposit = serv.SizeDeposit,
                    Email = serv.Email,
                    Name = serv.Name,
                    TypeValue = serv.TypeValue,
                    DateOpened = serv.DateOpened
                };
                list.Add(record);
            }
            return list;
        }
        public void SaveDepositsToPdfFile(ReportBindingModel model)
        {
            string title = "Депозит в банках";
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = title,
                Deposits = GetDeposits(model),
            });
        }
    }
}
