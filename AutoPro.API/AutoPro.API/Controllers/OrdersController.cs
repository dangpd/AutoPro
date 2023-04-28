using AutoPro.BL.BaseBL;
using AutoPro.BL.OrdersBL;
using AutoPro.Common.Entities;
using AutoPro.Common.Entities.DTO;
using AutoPro.Common.Entities.Param;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoPro.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : BaseController<Orders>
    {
        private IOrdersBL _ordersBL;
        public OrdersController(IOrdersBL ordersBL) : base(ordersBL)
        {
            _ordersBL = ordersBL;
        }

        /// <summary>
        /// Thêm mới dữ liệu hàng hóa
        /// </summary>
        /// <param name="entity">Dữ liệu được thêm</param>
        /// <returns></returns>
        /// CreatedBy: nvdien(17/8/2021)
        /// ModifiedBy: ndien(17/8/2021)
        [HttpPost("insertOrderDetail")]
        public async Task<IActionResult> insertOrderDetail(OrderDetailParam param)
        {
            try
            {
                var result = _ordersBL.InsertOrderDetail(param);
                // Thành công return 1
                if (result.IsSuccess)
                {
                    return StatusCode(StatusCodes.Status201Created, 1);
                }

                // Nếu result bằng false và errorcode == invalid data return lỗi nhập liệu
                else if (!result.IsSuccess && result.Data.ErrorCode == Common.Enum.ErrorCode.InvalidData)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
                    {
                        ErrorCode = result.Data.ErrorCode,
                        DevMsg = Common.Resource.DataResource.DevMsg_InvalidData,
                        UserMsg = Common.Resource.DataResource.UserMsg_InvalidData,
                        MoreInfo = result.Data.MoreInfo,
                        TraceId = HttpContext.TraceIdentifier
                    });
                }

                // Nếu kq trả về null return lỗi server
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                    {
                        ErrorCode = Common.Enum.ErrorCode.ServerError,
                        DevMsg = Common.Resource.DataResource.DevMsg_Exception,
                        UserMsg = Common.Resource.DataResource.UserMsg_Exception,
                        MoreInfo = Common.Resource.Resource.UserMsg_ServerError,
                        TraceId = HttpContext.TraceIdentifier
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.Exception,
                    DevMsg = Common.Resource.DataResource.DevMsg_Exception,
                    UserMsg = Common.Resource.DataResource.UserMsg_Exception,
                    MoreInfo = Common.Resource.Resource.UserMsg_ServerError,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        [HttpGet("getOrderDetail/{entityId}")]
        public IActionResult getOrderDetail(int entityId)
        {
            try
            {
                var result = _ordersBL.getOrderDetail(entityId);
                if(result == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                    {
                        ErrorCode = Common.Enum.ErrorCode.Exception,
                        DevMsg = Common.Resource.DataResource.DevMsg_Exception,
                        UserMsg = Common.Resource.DataResource.UserMsg_Exception,
                        MoreInfo = Common.Resource.Resource.UserMsg_ServerError,
                        TraceId = HttpContext.TraceIdentifier
                    });
                }
                return StatusCode(StatusCodes.Status200OK, result);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.Exception,
                    DevMsg = Common.Resource.DataResource.DevMsg_Exception,
                    UserMsg = Common.Resource.DataResource.UserMsg_Exception,
                    MoreInfo = Common.Resource.Resource.UserMsg_ServerError,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        [HttpPost("updateOrderDetail")]
        public IActionResult updateOrderDetail(OrderDetailParam param)
        {
            try
            {
                var result = _ordersBL.UpdateOrderDetail(param);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.Exception,
                    DevMsg = Common.Resource.DataResource.DevMsg_Exception,
                    UserMsg = Common.Resource.DataResource.UserMsg_Exception,
                    MoreInfo = Common.Resource.Resource.UserMsg_ServerError,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.Exception,
                    DevMsg = Common.Resource.DataResource.DevMsg_Exception,
                    UserMsg = Common.Resource.DataResource.UserMsg_Exception,
                    MoreInfo = Common.Resource.Resource.UserMsg_ServerError,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }


        [HttpGet("GetNewOrdersCode")]
        public IActionResult getOrderCodeAuto()
        {
            try
            {
                var result = _ordersBL.CreateAutoOrderCode();
                if(!string.IsNullOrEmpty(result))
                {
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.Exception,
                    DevMsg = Common.Resource.DataResource.DevMsg_Exception,
                    UserMsg = Common.Resource.DataResource.UserMsg_Exception,
                    MoreInfo = Common.Resource.Resource.UserMsg_ServerError,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.Exception,
                    DevMsg = Common.Resource.DataResource.DevMsg_Exception,
                    UserMsg = Common.Resource.DataResource.UserMsg_Exception,
                    MoreInfo = ex.ToString(),
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }
    }
}
