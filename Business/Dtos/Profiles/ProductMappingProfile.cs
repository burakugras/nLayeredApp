using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Profiles
{
    public class ProductMappingProfile:Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product,CreatedProductResponse>();

            CreateMap<Product, GetListProductResponse>().ReverseMap();
            CreateMap<Paginate<Product>,Paginate<GetListProductResponse>>().ReverseMap();
        }
    }
}
