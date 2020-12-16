using System;
using System.Collections.Generic;
using System.Text;

namespace StockTracing.DataAccess.DataBaseClasses
{
    public class stockProduct:LogTableBase
    {
        public Guid stockId { get; set; }
        public string serialNumber { get; set; }
        public int quantity { get; set; }
    }
}
