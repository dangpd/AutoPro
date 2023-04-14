using AutoPro.BL.BaseBL;
using AutoPro.Common.Entities;
using AutoPro.DL.CartDetailDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPro.BL.CartDetailBL
{
    public class CartDetailBL : BaseBL<CartDetail>,ICartDetailBL
    {
        private ICartDetailDL _cartDetailDL;

        public CartDetailBL(ICartDetailDL cartDetailDL) : base(cartDetailDL)
        {
            _cartDetailDL = cartDetailDL;
        }
    }
}
