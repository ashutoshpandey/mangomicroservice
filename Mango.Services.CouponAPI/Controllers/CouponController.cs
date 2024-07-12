using AutoMapper;
using Contracts;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private IMapper _mapper;
        private readonly AppDbContext _dbcontext;
        
        public CouponController(AppDbContext dbcontext, IMapper mapper)
        {
            _mapper = mapper;
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
                    return Ok(new ResponseDto()
                    {
                        IsSuccess = true,
                        Result = _mapper.Map<Coupon>(coupon)
                    });
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
                    new ResponseDto()
                    {
                        IsSuccess = false,
                        Message = ex.Message
                    }
                );
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var coupons = _dbcontext.Coupons.ToList();
                return Ok(new ResponseDto()
                {
                    IsSuccess = true,
                    Result = _mapper.Map<IEnumerable<CouponDto>>(coupons)
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ResponseDto()
                    {
                        IsSuccess = false,
                        Message = ex.Message
                    }
                );
            }
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public IActionResult GetByCode(string couponCode)
        {
            try
            {
                var coupon = _dbcontext.Coupons.First(c => c.CouponCode.ToLower() == couponCode.ToLower());
                return Ok(new ResponseDto()
                {
                    IsSuccess = true,
                    Result = _mapper.Map<CouponDto>(coupon)
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ResponseDto()
                    {
                        IsSuccess = false,
                        Message = ex.Message
                    }
                );
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CouponDto couponDto)
        {
            try
            {
                var coupon = _mapper.Map<Coupon>(couponDto);
                _dbcontext.Coupons.Add(coupon);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, new ResponseDto()
                {
                    IsSuccess = true,
                    Result = _mapper.Map<CouponDto>(coupon)
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ResponseDto()
                    {
                        IsSuccess = false,
                        Message = ex.Message
                    }
                );
            }
        }

        [HttpPut]
        [Route("{id:id}")]
        public IActionResult Update(int id, [FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon coupon = _dbcontext.Coupons.Find(id);
                if (coupon != null)
                {

                    _mapper.Map(couponDto, coupon);
                    _dbcontext.Coupons.Update(coupon);
                    _dbcontext.SaveChanges();

                    return StatusCode(StatusCodes.Status200OK, new ResponseDto()
                    {
                        IsSuccess = true,
                        Result = _mapper.Map<CouponDto>(coupon)
                    });
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
                    new ResponseDto()
                    {
                        IsSuccess = false,
                        Message = ex.Message
                    }
                );
            }
        }

        [HttpDelete]
        [Route("{id:id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Coupon coupon = _dbcontext.Coupons.Find(id);
                if (coupon != null)
                {
                    _dbcontext.Coupons.Remove(coupon);
                    _dbcontext.SaveChanges();

                    return StatusCode(StatusCodes.Status200OK, new ResponseDto()
                    {
                        IsSuccess = true,
                        Result = _mapper.Map<CouponDto>(coupon)
                    });
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
                    new ResponseDto()
                    {
                        IsSuccess = false,
                        Message = ex.Message
                    }
                );
            }
        }
    }
}
