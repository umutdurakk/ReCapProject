using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        T GetById(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);

    }
}
