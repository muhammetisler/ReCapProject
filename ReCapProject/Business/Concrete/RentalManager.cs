using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var result = _rentalDal.GetRentalDetails(x => x.CarId == rental.CarId);
            if (result.Count==0)
            {
               // araba id'si mevcutsa silinene kadar eklenmeyecek.
                    _rentalDal.Add(rental);
                    return new SuccessResult(Messages.RentalAdded);
                
                
            }
            return new ErrorResult();
          
        }

        public IResult Delete(Rental rental)
        {
          
            if (DateTime.Now.Day == rental.ReturnDate.Day)
            {
                //Belirlenen tarihe gelince delete fonksiyonu çalışacak
                _rentalDal.Delete(rental);
                return new SuccessResult();
                
            }
            return new ErrorResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsDto(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(p=>p.CarId==carId));
        }


    }
}
