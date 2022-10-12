using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(r => r.Description).MinimumLength(2);
            RuleFor(r=>r.ModelYear).GreaterThan(2000);
            RuleFor(r => r.DailyPrice).GreaterThan(10);
            
        }
    }
}
