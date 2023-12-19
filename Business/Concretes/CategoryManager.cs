using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        IMapper _mapper;
        CategoryBusinessRules _categoryBusinessRules;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest)
        {
            await _categoryBusinessRules.MaximumCategoryCountIsTen();

            Category category = _mapper.Map<Category>(createCategoryRequest);

            var createdCategory = await _categoryDal.AddAsync(category);

            CreatedCategoryResponse result = _mapper.Map<CreatedCategoryResponse>(createdCategory);

            return result;
        }

        public async Task<Category> Delete(int id)
        {
            var data = await _categoryDal.GetAsync(c => c.Id == id);
            data.DeletedDate = DateTime.Now;
            var result = await _categoryDal.DeleteAsync(data);
            return result;
        }

        public async Task<IPaginate<GetListCategoryResponse>> GetAll(PageRequest pageRequest)
        {
            var data = await _categoryDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
                );
            var result = _mapper.Map<Paginate<GetListCategoryResponse>>(data);
            return result;
        }

        public async Task<UpdatedCategoryResponse> Update(UpdateCategoryRequest updateCategoryRequest)
        {
            var data = await _categoryDal.GetAsync(c => c.Id == updateCategoryRequest.Id);

            _mapper.Map(updateCategoryRequest, data);
            data.UpdatedDate = DateTime.Now;

            await _categoryDal.UpdateAsync(data);

            var result=_mapper.Map<UpdatedCategoryResponse>(data);
            return result;
        }
    }
}
