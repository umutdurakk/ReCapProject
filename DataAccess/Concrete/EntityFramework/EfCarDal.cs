using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, EfRcpContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (EfRcpContext erc = new EfRcpContext())
            {
                var result = from c in erc.Cars
                             join b in erc.Brands
                             on c.BrandId equals b.BrandId
                             join o in erc.Colors
                             on c.ColorId equals o.ColorId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = o.ColorName,
                                 Description = c.Description,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
                             
            }
        }
    }
}
