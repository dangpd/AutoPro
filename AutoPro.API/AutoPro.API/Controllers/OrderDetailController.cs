using AutoPro.BL.BaseBL;
using AutoPro.BL.OrderDetailBL;
using AutoPro.Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoPro.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderDetailController : BaseController<OrderDetail>
    {
        private IOrderDetailBL _orderDetailBL;
        public OrderDetailController(IOrderDetailBL orderDetailBL) : base(orderDetailBL)
        {
            _orderDetailBL = orderDetailBL;
        }
    }
}
