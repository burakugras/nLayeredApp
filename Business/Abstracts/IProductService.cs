using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IProductService
    {
        Task<IPaginate<GetListProductResponse>> GetAll(PageRequest pageRequest);
        Task<CreatedProductResponse> Add(CreateProductRequest createProductRequest);
        Task<UpdatedProductResponse> Update(UpdateProductRequest updateProductRequest);
        Task<Product> Delete(int id);
        Task<CreatedProductResponse> GetById(int id);
        Task<CreatedProductResponse> GetByProductName(string name);

    }
}