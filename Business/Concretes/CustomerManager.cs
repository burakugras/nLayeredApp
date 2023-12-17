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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IMapper _mapper;
        CustomerBusinessRules _customerRules;

        public CustomerManager(ICustomerDal customerDal, IMapper mapper, CustomerBusinessRules customerRules)
        {
            _customerDal = customerDal;
            _mapper = mapper;
            _customerRules = customerRules;
        }

        public async Task<CreatedCustomerResponse> Add(CreateCustomerRequest createCustomerRequest)
        {
            await _customerRules.ContactNameRepeat(createCustomerRequest.ContactName);
            await _customerRules.MaxCityCount(createCustomerRequest.City);

            Customer customer = _mapper.Map<Customer>(createCustomerRequest);
            Customer createdCustomer = await _customerDal.AddAsync(customer);

            CreatedCustomerResponse createdCustomerResponse = _mapper.Map<CreatedCustomerResponse>(createdCustomer);
            return createdCustomerResponse;
        }

        public async Task<Customer> Delete(string id)
        {
            var data = await _customerDal.GetAsync(c => c.Id ==id);
            data.DeletedDate = DateTime.Now;
            var result = await _customerDal.DeleteAsync(data);
            return result;
        }

        public async Task<IPaginate<GetListCustomerResponse>> GetAll(PageRequest pageRequest)
        {
            var data = await _customerDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
                );

            var result = _mapper.Map<Paginate<GetListCustomerResponse>>(data);
            return result;
        }

        public async Task<UpdatedCustomerResponse> Update(UpdateCustomerRequest updateCustomerRequest)
        {
            var data=await _customerDal.GetAsync(c=>c.Id == updateCustomerRequest.Id);

            _mapper.Map(updateCustomerRequest, data);
            data.UpdatedDate = DateTime.Now;

            await _customerDal.UpdateAsync(data);

            var result=_mapper.Map<UpdatedCustomerResponse>(data);
            return result;
        }
    }
}
