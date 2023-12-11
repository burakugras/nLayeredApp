﻿using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            /*
            CreateMap<Product, GetListProductResponse>().ForMember(destinationMember: p => p.CategoryName, memberOptions: opt => opt.MapFrom(p => p.Category.Name)).ReverseMap();

            CreateMap<CreateProductRequest, Product>();
            //CreateMap<Product, CreatedProductResponse>();

            CreateMap<Product, GetListProductResponse>().ReverseMap();
            CreateMap<Paginate<Product>, Paginate<GetListProductResponse>>().ReverseMap();

            */


            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, CreatedProductResponse>();
            //GetListResponse İçin

            CreateMap<Product, GetListProductResponse>().ForMember(destinationMember: p => p.CategoryName, memberOptions: opt => opt.MapFrom(p => p.Category.Name)).ReverseMap();
            CreateMap<Paginate<Product>, Paginate<GetListProductResponse>>();
        }
    }
}