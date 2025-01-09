﻿using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators
{
    public class PriceValidator : AbstractValidator<Price>
    {
        public PriceValidator() 
        {
            RuleFor(x => x.Amount)
                    .NotEmpty()
                    .PrecisionScale(18, 2, false);
        }
    }
}
