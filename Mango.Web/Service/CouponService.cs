using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Url = SD.CouponAPIBase + "/api/coupon/" + id,
                ApiType= SD.ApiType.DELETE
            });
        }

        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Url = SD.CouponAPIBase+ "/api/coupon",
                ApiType= SD.ApiType.GET
            });
        }

        public async Task<ResponseDto?> GetCouponAsync(string coupon)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Url = SD.CouponAPIBase + "/api/coupon/GetByCode/" + coupon,
                ApiType= SD.ApiType.GET
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Url = SD.CouponAPIBase + "/api/coupon/" + id,
                ApiType= SD.ApiType.GET
            });

        }

        public async Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Url=SD.CouponAPIBase + "/api/coupon",
                ApiType= SD.ApiType.POST,
                Data= couponDto
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Url=SD.CouponAPIBase + "/api/coupon",
                ApiType= SD.ApiType.PUT,
                Data= couponDto
            });

        }
    }
}
