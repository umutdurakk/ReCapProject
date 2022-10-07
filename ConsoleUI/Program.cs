using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car
            {
                Id= 1,
                BrandId=1,
                ColorId=2,
                DailyPrice=10,
                Description="Toyota",
                ModelYear=2021
            });

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }
        }
    }
}