﻿using AutoMapper;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;

namespace Mango.Services.CouponAPI
{
    public static class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });
        }
    }
}
