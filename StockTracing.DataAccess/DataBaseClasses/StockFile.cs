﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StockTracing.DataAccess.DataBaseClasses
{
    public class StockFile:LogTableBase
    {
        public Guid stockId { get; set; }
        public string FileDescription { get; set; }
        public string file { get; set; }
    }
}
