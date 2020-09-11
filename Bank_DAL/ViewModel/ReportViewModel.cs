using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_DAL.ViewModel
{
    public class ReportViewModel
    {
        public string Name { get; set; }
        public DateTime DateOpened { get; set; }
        public string ClientFIO { get; set; }
        public string TypeValue { get; set; }
        public int SizeDeposit { get; set; }

    }
}
