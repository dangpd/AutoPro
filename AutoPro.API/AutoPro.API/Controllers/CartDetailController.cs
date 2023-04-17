using AutoPro.BL.BaseBL;
using AutoPro.BL.CartDetailBL;
using AutoPro.Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoPro.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CartDetailController : BaseController<CartDetail>
    {
        private ICartDetailBL _cartDetailBL;
        public CartDetailController(ICartDetailBL cartDetailBL) : base(cartDetailBL)
        {
            _cartDetailBL = cartDetailBL;
        }
    }
}
