using AutoPro.BL.BaseBL;
using AutoPro.BL.UserBL;
using AutoPro.Common.Entities;
using AutoPro.Common.Entities.DTO;
using AutoPro.Common.Entities.Param;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoPro.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : BaseController<User>
    {
        private IUserBL _userBL;

        public UserController(IUserBL userBL) : base(userBL)
        {
            _userBL = userBL;
        }

        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult LoginApplication([FromBody] AccountLogin userLogin)
        {
            try
            {
                var result = _userBL.checkLogin(userLogin.Account, userLogin.Password);
                if (result == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
                    {
                        ErrorCode = Common.Enum.ErrorCode.InvalidData,
                        DevMsg = Common.Resource.DataResource.DevMsg_InvalidData,
                        UserMsg = Common.Resource.DataResource.UserMsg_InvalidData,
                        MoreInfo = Common.Resource.Resource.UserMsg_LoginFail,
                        TraceId = HttpContext.TraceIdentifier
                    });
                }
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                // Lỗi exception
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

    }
}
