using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    internal class EfColorDal : IColorDal
    {
        public void Add(Color Entity)
        {
            using (EfRcpContext context = new EfRcpContext())
            {
                var addedContext = context.Entry(Entity);
                addedContext.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color Entity)
        {
            using (EfRcpContext context = new EfRcpContext())
            {
                var deletedContext = context.Entry(Entity);
                deletedContext.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(Color Entity)
        {
            using (EfRcpContext context = new EfRcpContext())
            {
                var updatedContext = context.Entry(Entity);
                updatedContext.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<Color>  GetAll(Expression<Func<Color, bool>> filter)
        {
            using (EfRcpContext context = new EfRcpContext())
            {
                return filter == null ? context.Set<Color>().ToList() :
                    context.Set<Color>().Where(filter).ToList();
            }
        }

        public Color GetById(Expression<Func<Color, bool>> filter)
        {
            using (EfRcpContext context = new EfRcpContext())
            {
                return context.Set<Color>().FirstOrDefault(filter);
            }
        }
    }
}
