using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Brand Get(int brandId)
        {
           return _brandDal.GetById(b=>b.BrandId==brandId);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }
    }
}
