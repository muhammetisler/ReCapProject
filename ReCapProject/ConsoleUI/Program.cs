using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
   public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
           {
             Console.WriteLine(car.ColorName + " rengine sahip " + car.BrandName + " arabanın günlük fiyatı: " + car.DailyPrice);
                
             }


            UserManager userManager = new UserManager(new EfUserDal());
            //User user = new User();
            //user.FirstName = "Eren";
            //user.LastName = "Ugur";
            //user.Email = "deneme@gmail.com";
            //user.password = "123456789";
            //userManager.Add(user);

            //User user2 = new User();
            //user2.FirstName = "Furkan";
            //user2.LastName = "Yıldız";
            //user2.Email = "deneme2@gmail.com";
            //user2.password = "123456789";
            //userManager.Add(user2);


            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //Customer musteri = new Customer();
            //musteri.CompanyName = "Doge A.Ş";
            //musteri.UserId = 1; //eren kullanıcısyla müşteriyi eşledik
            //customerManager.Add(musteri);
            //Customer musteri2 = new Customer();
            //musteri2.CompanyName = "Holo A.Ş";
            //musteri2.UserId = 2;
            //customerManager.Add(musteri2);

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental1 = new Rental();
            rental1.CarId = 1;
            rental1.CustomerId = 1;
            rental1.RentDate=DateTime.Now;
            rental1.ReturnDate = DateTime.Now.AddDays(2); // geri verme tarihi 2 gün sonra
            //rentalManager.Add(rental1);
            rentalManager.Delete(rental1);

            Rental rental2 = new Rental();
            rental2.CarId = 1; // aynı arabayı başka müşteri ile almayı deniyoruz.
            rental2.CustomerId = 2;
            rental2.RentDate = DateTime.Now;
            rental2.ReturnDate = DateTime.Now.AddDays(2);
            //   rentalManager.Add(rental2);
            // İlk araba kaydı silinene kadar eklemiyor







        }
    }
}
