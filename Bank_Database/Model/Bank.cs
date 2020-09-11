using Bank_DAL.BindingModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_Database.Model
{
    public class Bank
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime DateCreate { get; set; }
        public List<DepositBindingModel> Deposits { get; set; }
    }
}
