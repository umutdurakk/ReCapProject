using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Delete(Rental rental)
        {
            
            _rentalDal.Delete(rental);
            return new SuccessResult(Message.DeletedRental);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Message.RentalsListed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetById(r=>r.RentalId==rentalId), Message.RentalListed);
        }

        public IResult Insert(Rental rental)
        {
            if (rental.ReturnDate==null)
            {
                return new ErrorResult(Message.RentalAddError);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Message.AddedRental);
        }

        public IResult Update(Rental rental)
        {
            
            _rentalDal.Update(rental);
            return new SuccessResult(Message.UpdatedRental);
        }
    }
}
