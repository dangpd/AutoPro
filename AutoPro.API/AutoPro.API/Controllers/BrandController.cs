using AutoPro.BL.BaseBL;
using AutoPro.Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoPro.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BrandController : BaseController<Brand>
    {
        public BrandController(IBaseBL<Brand> baseBL) : base(baseBL)
        {
        }
    }
}
