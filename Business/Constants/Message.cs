using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Message
    {
        public static string MaintenanceTime = "Sistem Bakımda.";

        //Car
        public static string CarAdded = "Araba eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string CarsListed = "Arabalar Listelendi.";
        public static string CarDelete = "Araba Silindi.";
        public static string CarUpdate ="Araba güncellendi.";
        public static string CarsDetailListed = "Araba Detayları listelendi.";
        public static string CarsByBrandListed = "Araba markasına göre listelendi.";
        public static string GetCarsByColorListed = "Arabalar renklere göre listelendi.";
        public static string CarListed = "Araba gösteriliyor.";

        //Brand
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandsListed = "Markalar listelendi.";
        public static string BrandListed = "Marka gösterildi.";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string BrandDeleted = "Marka silindi.";
        //Rental
        public static string RentalAddError = "Araba teslim edilmemiştir.";
        public static string AddedRental = "Rental Eklendi.";
        public static string UpdatedRental = "Kiralama verisi güncellendi. ";
        public static string DeletedRental = "Kiralama verisi silindi.";
        public static string RentalsListed = "Kiralama verileri listelendi.";
        public static string RentalListed = "Kiralama verisi gösteriliyor.";

        //Customer
        public static string CustomerDelete = "Müşteri silindi.";
        public static string CustomerListed = "Müşteri gösterildi.";
        public static string CustomersListed = "Müşteriler listelendi.";
        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerDetailListed = "Kullanıcı detayları gösteriliyor.";

        //User
        public static string DeletedUser = "Kullanıcı silindi.";
        public static string AddedUser = "Kullanıcı eklendi.";
        public static string UpdatedUser = "Kullanıcı güncellendi.";
        public static string UsersListed = "Kullanıcılar listelendi";
        public static string UserListed = "Kullanıcı gösterildi.";

        
    }
}
