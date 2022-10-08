using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Message.CustomerDelete);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Message.CustomersListed);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.GetById(c => c.CustomerId == customerId), Message.CustomerListed);
        }

        public IDataResult<List<CustomerDetailDto>> getCustomerDetail()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.customerDetailDtos(), Message.CustomerDetailListed);
        }

        public IResult Insert(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Message.CustomerAdded);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Message.CustomerUpdated);
        }
    }
}
