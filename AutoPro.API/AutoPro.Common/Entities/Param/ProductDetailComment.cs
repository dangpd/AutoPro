﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPro.Common.Entities.Param
{
    public class ProductDetailComment
    {
        public int IdOrderDetail {  get; set; }
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }

    }
}
