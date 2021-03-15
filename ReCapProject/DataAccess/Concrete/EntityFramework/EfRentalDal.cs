using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,ReCapDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {

            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from r in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cu in context.Customers
                             on r.CustomerId equals cu.Id
                             join u in context.Users
                             on cu.UserId equals u.Id
                             select new RentalDetailDto
                             {
                               Id=r.Id,
                               CarId=r.CarId,
                               BrandName = b.BrandName,
                               CompanyName = cu.CompanyName,
                               Decription = c.Description,
                               ModelYear = c.ModelYear,
                               RentDate = r.RentDate,
                               ReturnDate = r.ReturnDate,
                               DailyPrice = c.DailyPrice,
                               FirstName = u.FirstName,
                               LastName = u.LastName
                             };

                return result.ToList();

            }
        }
    }
}
