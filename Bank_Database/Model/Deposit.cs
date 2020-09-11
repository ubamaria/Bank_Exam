using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bank_Database.Model
{
    public class Deposit
    {
        public int? Id { get; set; }
        public int BankId { get; set; }

        public string ClientFIO { get; set; }
        public int SizeDeposit { get; set; }

        public string Email { get; set; }

        public DateTime DateOpened { get; set; }
        public string TypeValue { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        [ForeignKey("DepositId")]
        public virtual Bank Bank { get; set; }
    }
}
