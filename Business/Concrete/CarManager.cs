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
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Insert(Car car)
        {
            if (car.Description.Length>=2 && car.DailyPrice>0)
            {
                _carDal.Add(car);
               return new SuccessResult(Message.CarAdded);
            }
            else
            {
                return new SuccessResult(Message.CarNameInvalid);
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
           return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Message.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail(), Message.CarsDetailListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id),Message.CarsByBrandListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id),Message.GetCarsByColorListed);
        }


        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Message.CarUpdate);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Message.CarDelete);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.GetById(c => c.Id == id),Message.CarListed);
        }
    }
}
