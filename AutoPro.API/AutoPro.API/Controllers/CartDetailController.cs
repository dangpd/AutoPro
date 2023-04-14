using AutoPro.BL.BaseBL;
using AutoPro.Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoPro.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CartDetailController : BaseController<CartDetail>
    {
        public CartDetailController(IBaseBL<CartDetail> baseBL) : base(baseBL)
        {
        }
    }
}
