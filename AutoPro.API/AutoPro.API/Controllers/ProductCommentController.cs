using AutoPro.BL.BaseBL;
using AutoPro.BL.ProductCommentBL;
using AutoPro.Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoPro.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductCommentController : BaseController<ProductComment>
    {
        private IProductCommentBL _productCommentBL;
        public ProductCommentController(IProductCommentBL productCommentBL) : base(productCommentBL)
        {
            _productCommentBL = productCommentBL;
        }
    }
}
