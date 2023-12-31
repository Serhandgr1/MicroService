﻿using AutoMapper;
using Azure;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductModel, LikeDataModel>()
                .ForMember(destination => destination.ProductId , operation =>operation.MapFrom(source => source.ProductId))
                .ForMember(destination => destination.LikeId, operation => operation.MapFrom(source => source.ProductId))
                .ForMember(destination => destination.UserId, operation => operation.MapFrom(source => source.ProductId));
            CreateMap<ProductModel, KampanyaProductModel>()
                .ForMember(destination => destination.ProductId, operation => operation.MapFrom(source => source.ProductId))
                .ForMember(destination => destination.KampanyaId, operation => operation.MapFrom(source => source.CategoryId));
            CreateMap<KampanyaProductModel, ProductModel>()
                .ForMember(destination => destination.ProductId, operation => operation.MapFrom(source => source.ProductId))
                .ForMember(destination => destination.CategoryId, operation => operation.MapFrom(source => source.KampanyaId));
        }
    }
}
