using FluentValidation;
using PruebasHexagonal.Application.Communication.V1.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasHexagonal.Infrastructure.Validators.V1
{
    public class UserGetValidator : AbstractValidator<UserGetRequest>
    {
        public UserGetValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId cannot be empty.")
                .NotNull().WithMessage("UserId cannot be null.");
        }
    }
}
