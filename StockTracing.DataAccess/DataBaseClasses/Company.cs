using System;
using System.Collections.Generic;
using System.Text;

namespace StockTracing.DataAccess.DataBaseClasses
{
    public class Company : LogTableBase
    {
        public string Name { get; set; }
        public string taxNo { get; set; }
        public string adress { get; set; }
        public string eMail { get; set; }
        public string Phone { get; set; }
        public string webSite { get; set; }
        public bool isShipping { get; set; } //kargo mu normal şirket mi
    }
}
