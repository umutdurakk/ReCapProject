using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Message.DeletedUser);
        }

        public IDataResult<List<User>> GetAll()
        {
          return new SuccessDataResult<List<User>>(_userDal.GetAll(),Message.UsersListed);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.GetById(u=>u.UserId==userId),Message.UserListed);
        }

        public IResult Insert(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Message.AddedUser);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Message.UpdatedUser);
        }
    }
}
