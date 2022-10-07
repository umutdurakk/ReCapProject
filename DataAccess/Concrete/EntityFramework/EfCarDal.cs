﻿using DataAccess.Abstract;
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
    public class EfCarDal : ICarDal
    {
        public void Add(Car Entity)
        {
            using (EfRcpContext context = new EfRcpContext())
            {
                var addedContext = context.Entry(Entity);
                addedContext.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car Entity)
        {
            using (EfRcpContext context = new EfRcpContext())
            {
                var deletedContext = context.Entry(Entity);
                deletedContext.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (EfRcpContext context = new EfRcpContext())
            {
                return filter == null ? context.Set<Car>().ToList() :
                    context.Set<Car>().Where(filter).ToList();
            }

        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            using (EfRcpContext context = new EfRcpContext())
            {
                return context.Set<Car>().FirstOrDefault(filter);
            }
        }

        public void Update(Car Entity)
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
