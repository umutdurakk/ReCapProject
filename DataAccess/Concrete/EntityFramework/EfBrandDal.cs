using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    internal class EfBrandDal : IBrandDal
    {
        public void Add(Brand Entity)
        {
           using (EfRcpContext context = new EfRcpContext())
            {
                var addedContext= context.Entry(Entity);
                addedContext.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand Entity)
        {
            using (EfRcpContext context = new EfRcpContext())
            {
                var deletedContext = context.Entry(Entity);
                deletedContext.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (EfRcpContext context = new EfRcpContext())
            {
                return filter == null ? context.Set<Brand>().ToList() :
                    context.Set<Brand>().Where(filter).ToList() ;
            }
            
        }

        public Brand GetById(Expression<Func<Brand, bool>> filter)
        {
            using (EfRcpContext context = new EfRcpContext())
            {
                return context.Set<Brand>().FirstOrDefault(filter);
            }
        }

        public void Update(Brand Entity)
        {
            using (EfRcpContext context = new EfRcpContext())
            {
                var updatedContext = context.Entry(Entity);
                updatedContext.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
