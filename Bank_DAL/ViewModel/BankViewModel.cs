using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_DAL.ViewModel
{
    public class BankViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime DateCreate { get; set; }
        public List<DepositViewModel> Deposits { get; set; }

    }
}
