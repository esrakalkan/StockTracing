﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StockTracing.DataAccess.DataBaseClasses
{
    public class LogTableBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();    //emsalsiz key verir

        public DateTime lastUpdate { get; set; } = DateTime.Now;

        public string editedBy { get; set; }
        public bool deleted { get; set; } = false;  
        public DateTime createdDate { get; set; }
        public string createdBy { get; set; }
    }
}
