using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();

        IDataResult<Customer> GetById(int customerId);

        IResult Insert(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
        IDataResult<List<CustomerDetailDto>> getCustomerDetail();
    }
}
