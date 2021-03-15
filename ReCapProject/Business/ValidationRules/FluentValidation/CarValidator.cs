using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).MinimumLength(2).WithMessage("Araç adı en az 2 karakter uzunluğunda olmalıdır.");
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Aracın günlük fiyatı 0'dan büyük olmalıdır.");
            RuleFor(c => c.ModelYear).GreaterThan(0).WithMessage("Aracın model yılı 0'dan büyük olmalıdır.");
            RuleFor(c => c.Description).MinimumLength(5).WithMessage("Araç açıklaması en az 5 karakter uzunluğunda olmalıdır.");
        }
    }
}
