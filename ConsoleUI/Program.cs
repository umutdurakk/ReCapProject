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
           // getDetailCustomerTest();
        }

        private static void getDetailCustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.getCustomerDetail();

            foreach (var item in result.Data.ToList())
            {
                Console.WriteLine(item.FirstName);
            }
        }

        private static void CarAddedTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Insert(new Car
            {
                BrandId = 1,
                ColorId = 1,
                Id = 3,
                DailyPrice = 11,
                Description = "Güzell",
                ModelYear = 2002

            });
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
           var result= rentalManager.Insert(new Rental
            {
                CarId = 1,
                CustomerId = 1,
                RentalId = 1,
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Today,


            }).Message;
            Console.WriteLine(result);
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var item in carManager.GetCarDetail().Data)
            {
                Console.WriteLine(item.Description + " / " + item.ColorName + " / " + item.BrandName);
            }
        }
    }
}