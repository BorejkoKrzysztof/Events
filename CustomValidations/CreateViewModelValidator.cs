using Events.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.CustomValidations
{
    public class CreateViewModelValidator : AbstractValidator<CreateViewModel>
    {
        public CreateViewModelValidator()
        {
            // Name
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Name).MaximumLength(35).WithMessage("Name's max length is 35");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Name's min length is 3");


            //TicketPrice
            RuleFor(x => x.TicketPrice).GreaterThanOrEqualTo(0).WithMessage("Min Ticket price equals 0 and Max equals 250 000");
            RuleFor(x => x.TicketPrice).LessThanOrEqualTo(250000).WithMessage("Min Ticket price equals 0 and Max equals 250 000");


            //Currency
            RuleFor(x => x.Currency).NotEmpty().When(x => x.TicketPrice > 0)
                                                .WithMessage("Currency field is required if Ticket price is not 0");

        }
    }
}
