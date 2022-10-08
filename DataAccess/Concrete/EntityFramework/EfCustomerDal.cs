using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, EfRcpContext>, ICustomerDal
    {
        public List<CustomerDetailDto> customerDetailDtos()
        {
            using (EfRcpContext context = new EfRcpContext()) 
            { 

                var cdd = from u in context.Users
                          join c in context.Customers
                          on u.UserId equals c.UserId
                          select new CustomerDetailDto
                          {
                              CompanyName = c.CompanyName,
                              CustomerId = c.CustomerId,
                              Email = u.Email,
                              FirstName = u.FirstName,
                              LastName = u.LastName,
                              UserId = u.UserId
                          };
            return cdd.ToList();
            }
        }
    }
}
