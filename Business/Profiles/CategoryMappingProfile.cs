using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<Category, CreatedCategoryResponse>();

            CreateMap<Category,GetListCategoryResponse>().ReverseMap();
            CreateMap<Paginate<Category>, Paginate<GetListCategoryResponse>>().ReverseMap();

            CreateMap<UpdateCategoryRequest, Category>().ForMember(dest => dest.CreatedDate, opt => opt.Ignore()); 
            CreateMap<Category, UpdatedCategoryResponse>().ReverseMap();


        }
    }
}
