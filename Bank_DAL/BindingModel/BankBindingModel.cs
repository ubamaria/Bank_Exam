using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_DAL.BindingModel
{
    public class BankBindingModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime DateOpened { get; set; }
        public List<DepositBindingModel> Deposits { get; set; }

    }
}
