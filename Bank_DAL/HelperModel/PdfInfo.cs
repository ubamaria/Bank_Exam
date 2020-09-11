using Bank_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_DAL.HelperModel
{
    public class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<DepositViewModel> Deposits { get; set; }
    }
}
