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
    public interface ICustomerService
    {
        Task<IPaginate<GetListCustomerResponse>> GetAll(PageRequest pageRequest);
        Task<CreatedCustomerResponse> Add(CreateCustomerRequest createCustomerRequest);
        Task<CreatedCustomerResponse> Update(UpdateCustomerRequest updateCustomerRequest);
        Task<Customer> Delete(string id, bool permanent);        
    }
}
