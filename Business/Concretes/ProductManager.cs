using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Concretes
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        IMapper _mapper;
        ProductBusinessRules _productBusinessRules;

        public ProductManager(IProductDal productDal, IMapper mapper, ProductBusinessRules businessRules)
        {
            _productDal = productDal;
            _mapper = mapper;
            _productBusinessRules = businessRules;
        }

        public async Task<CreatedProductResponse> Add(CreateProductRequest createProductRequest)
        {

            await _productBusinessRules.MaximumProductCountIsTwenty(createProductRequest.CategoryId);

            Product product = _mapper.Map<Product>(createProductRequest);
            Product createdProduct = await _productDal.AddAsync(product);
            CreatedProductResponse createdProductResponse = _mapper.Map<CreatedProductResponse>(createdProduct);
            return createdProductResponse;

        }

        public async Task<Product> Delete(int id)
        {
            var data=await _productDal.GetAsync(p=>p.Id==id);
            data.DeletedDate= DateTime.Now;
            var result=await _productDal.DeleteAsync(data);
            return result;
        }

        public async Task<IPaginate<GetListProductResponse>> GetAll(PageRequest pageRequest)
        {

            var data = await _productDal.GetListAsync(include: p => p.Include(p => p.Category),
                index:pageRequest.PageIndex,
                size:pageRequest.PageSize);
            var result = _mapper.Map<Paginate<GetListProductResponse>>(data);
            return result;

        }

        public async Task<UpdatedProductResponse> Update(UpdateProductRequest updateProductRequest)
        {
            var data = await _productDal.GetAsync(p => p.Id == updateProductRequest.Id);
            _mapper.Map(updateProductRequest, data);
            data.UpdatedDate = DateTime.Now;

            await _productDal.UpdateAsync(data);

            var result = _mapper.Map<UpdatedProductResponse>(data);
            return result;

        }

        public async Task<CreatedProductResponse> GetById(int id)
        {
            var data = await _productDal.GetAsync(p => p.Id == id);
            var result=_mapper.Map<CreatedProductResponse>(data);
            return result;
        }
    }
}

