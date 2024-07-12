using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly AppDbContext _dbcontext;
        
        public CouponController(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                Coupon coupon = _dbcontext.Coupons.First(c => c.CouponId == id);
                if (coupon != null)
                {
                    return Ok(coupon);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { message = ex.Message }
                );
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_dbcontext.Coupons.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { message = ex.Message }
                );
            }
        }
    }
}
