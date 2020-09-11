using Bank_DAL.BindingModel;
using Bank_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_DAL.Interface
{
    public interface IDepositLogic
    {
        List<DepositViewModel> Read(DepositBindingModel model);
        void CreateOrUpdate(DepositBindingModel model);
        void Delete(DepositBindingModel model);
    }
}
