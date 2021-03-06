﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_DAL.BindingModel
{
    public class DepositBindingModel
    {
        public int? Id { get; set; }
        public int BankId { get; set; }

        public string ClientFIO { get; set; }
        public int SizeDeposit { get; set; }

        public string Email { get; set; }

        public DateTime DateOpened  { get; set;  }
        public string TypeValue { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

    }
}