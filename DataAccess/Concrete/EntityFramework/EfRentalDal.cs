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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, EfRcpContext>, IRentalDal
    {
        public List<RentalDetailDto> rentalDetailDtos()
        {
            using(var context =new EfRcpContext() )
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id

                             join b in context.Brands
                             on c.BrandId equals b.BrandId

                             join custo in context.Customers
                             on r.CustomerId equals custo.CustomerId

                             join u in context.Users
                             on custo.UserId equals u.UserId

                             select new RentalDetailDto
                             {
                                 BrandName = b.BrandName,
                                 Name = u.FirstName + " " + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();

                            

            }
        }
    }
}
