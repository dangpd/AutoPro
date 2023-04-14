using AutoPro.BL.BaseBL;
using AutoPro.Common.Entities;
using AutoPro.DL.ProductDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPro.BL.ProductBL
{
    public class ProductBL : BaseBL<Product>,IProductBL
    {
        private IProductDL _productDL;

        public ProductBL(IProductDL productDL) : base(productDL)
        {
            _productDL = productDL;
        }
    }
}
