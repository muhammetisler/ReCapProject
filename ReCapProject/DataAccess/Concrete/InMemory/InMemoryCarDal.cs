using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _Cars;
        List<Color> _Colors;
        List<Brand> _Brands;

        public InMemoryCarDal()
        {
            _Cars = new List<Car>
            {
                new Car {Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 1000, ModelYear = 2000, Description = "otomatik dizel"},
                new Car {Id = 2, BrandId = 1, ColorId = 1, DailyPrice = 2000, ModelYear = 2010, Description = "otomatik benzin"},
                new Car {Id = 3, BrandId = 2, ColorId = 2, DailyPrice = 1000, ModelYear = 2012, Description = "manuel dizel"},
                new Car {Id = 4, BrandId = 3, ColorId = 3, DailyPrice = 7500, ModelYear = 2015, Description = "manuel benzin"},
                new Car {Id = 5, BrandId = 2, ColorId = 4, DailyPrice = 3500, ModelYear = 2010, Description = "yarıotomatik dizel"},
            };

            _Colors = new List<Color>
            {
                new Color {Id = 1, ColorName = "Siyah"},
                new Color {Id = 2, ColorName = "Beyaz"},
                new Color {Id = 3, ColorName = "Mavi"},
                new Color {Id = 4, ColorName = "Kırmızı"},
            };

            _Brands = new List<Brand>
            {
                new Brand {Id = 1, BrandName = "MERCEDES"},
                new Brand {Id = 2, BrandName = "BMW"},
                new Brand {Id = 3, BrandName = "TOGG"}
            };
            
        }

        public void JoinShow(List<Car> cars)
        {
            var Cars = from c in cars
                       join co in _Colors
                     on c.ColorId equals co.Id
                       join b in _Brands
                       on c.BrandId equals b.Id
                       select new CarDto { Id = c.Id, BrandName = b.BrandName, ColorName = co.ColorName, DailyPrice = c.DailyPrice, ModelYear = c.ModelYear, Description = c.Description };
            foreach (var car in Cars)
            {
                Console.WriteLine("{0} {1}", car.BrandName, car.ColorName);
            }
        }

        public void Add(Car car)
        {
            _Cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _Cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            var referance = _Cars.SingleOrDefault(c => c.Id == car.Id);
            _Cars.Remove(referance);
        }

        public List<Car> GetAll()
        {
            return _Cars;
        }

        public List<Car> GetById(int id)
        {
           
            return _Cars.Where(car => car.Id == id).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
