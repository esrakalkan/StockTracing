using System;
using System.Collections.Generic;
using System.Text;

namespace StockTracing.DataAccess.DataBaseClasses
{
    public class Stock:LogTableBase
    {
        public Guid inComingCompanyId { get; set; }

        public Guid outComingCompanyId { get; set; }
        public Guid? shippingCompanyId { get; set; }

        public Guid? shippingUserId { get; set; }
        public string invoiceNo { get; set; }
        public string barcodeNo { get; set; }

        public Guid recieverPerson { get; set; }

        public Guid deliverPerson { get; set; }

        public DateTime date { get; set; }

        public bool? confirm { get; set; }
        public Guid confirmById { get; set; }
        public DateTime confirmDate { get; set; }
        public string confirmNote { get; set; }
    }
}
