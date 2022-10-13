using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;


namespace Business.Concrete

{  public class CarImageManager : ICarImageService
  {
      ICarImageDal _carImageDal;
      IFileHelper _fileHelper;

      public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
      {
          _carImageDal = carImageDal;
          _fileHelper = fileHelper;
      }

      public IResult Add(IFormFile file, CarImage carImage)
      {
            var result = BusinessRules.Run(MaxFiveImageCheck(carImage.CarId));
            if (result.Success)
            {
                carImage.ImagePath = _fileHelper.Upload(file, FilePath.ImagesPath);
                carImage.Date = DateTime.Now;
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.ItemAdded);
            }
            return new ErrorResult();

      }

      public IResult Delete(CarImage carImage)
      {
          _fileHelper.Delete(FilePath.ImagesPath + carImage.ImagePath);
          _carImageDal.Delete(carImage);
          return new SuccessResult();
      }

      public IDataResult<List<CarImage>> GetAll()
      {
          return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(),Messages.ImagesGettingDone);
      }

      public IDataResult<List<CarImage>> GetByCarId(int carId)
      {
           BusinessRules.Run(DefaultImage(carId));
           
          return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c=>c.CarId==carId), Messages.ImagesGettingDone);
      }

      public IDataResult<CarImage> GetByImageId(int imageId)
      {
          return new SuccessDataResult<CarImage>(_carImageDal.GetById(c=>c.CarImageId==imageId), Messages.ImageGettingDone);
      }

      public IResult Update(IFormFile file,CarImage carImage)
      {
          carImage.ImagePath = _fileHelper.Update(file, FilePath.ImagesPath + carImage.ImagePath, FilePath.ImagesPath);
          _carImageDal.Update(carImage);
          return new SuccessResult();
      }
        private IResult MaxFiveImageCheck(int carId)
        {
            var result = _carImageDal.GetAll(x => x.CarId==carId).Count;
            if (result>=5)
            {
                return new ErrorResult("En fazla beş resim");
            }
            return new SuccessResult();
        }
        private IResult DefaultImage(int carId)
        {
            var result = _carImageDal.GetAll(x => x.CarId == carId).Count;
            List<CarImage> images = new List<CarImage>();

            if (result == 0)
            {
               _carImageDal.Add(new CarImage
               {
                   CarId = carId,
                   ImagePath="indir.png",
                   Date = DateTime.Now,
               });
                return new SuccessResult("Default resim atıldı");
             
            }
            return new SuccessResult();
        }
    }
}
