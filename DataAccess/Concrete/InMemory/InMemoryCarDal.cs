using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
       public InMemoryCarDal()
        {
            _cars=new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=100,Description="Toyota",ModelYear=2008},
                new Car{Id=2,BrandId=1,ColorId=2,DailyPrice=200,Description="Audi",ModelYear=2010},
                new Car{Id=3,BrandId=2,ColorId=3,DailyPrice=300,Description="Yamaha",ModelYear=2020},
                new Car{Id=4,BrandId=2,ColorId=2,DailyPrice=200,Description="Wolswogen",ModelYear=2014},
                new Car{Id=5,BrandId=2,ColorId=3,DailyPrice=150,Description="Modriel",ModelYear=2022},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete =_cars.SingleOrDefault(x => x.Id==car.Id);
            _cars.Remove(carToDelete);
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(x => x.Id == car.Id);
            carToUpdate.Description = "ibibik";
        }
        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int brandId)
        {
            List<Car> carToId = _cars.Where(x => x.BrandId == brandId).ToList();
            return carToId;
        }

       
    }
}
