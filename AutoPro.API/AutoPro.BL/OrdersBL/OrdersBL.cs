using AutoPro.BL.BaseBL;
using AutoPro.Common.Entities;
using AutoPro.DL.OrdersDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPro.BL.OrdersBL
{
    public class OrdersBL : BaseBL<Orders>,IOrdersBL
    {
        private IOrdersDL _ordersDL;

        public OrdersBL(IOrdersDL ordersDL) : base(ordersDL)
        {
            _ordersDL = ordersDL;
        }
    }
}
