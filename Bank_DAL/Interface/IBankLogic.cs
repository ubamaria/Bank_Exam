using Bank_DAL.BindingModel;
using Bank_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_DAL.Interface
{
    public interface IBankLogic
    {
        List<BankViewModel> Read(BankBindingModel model);
        void CreateOrUpdate(BankBindingModel model);
        void Delete(BankBindingModel model);
    }
}
