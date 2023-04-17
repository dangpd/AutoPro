using AutoPro.BL.BaseBL;
using AutoPro.BL.ProductBL;
using AutoPro.Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoPro.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : BaseController<Product>
    {
        private IProductBL _productBL;
        public ProductController(IProductBL productBL) : base(productBL)
        {
            _productBL = productBL;
        }
    }
}
