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






































            //TicketQuantity
       //     RuleFor(x => x.TicketQuantity).NotEmpty().WithMessage("Ticket quantity is required");
       //     RuleFor(x => x.TicketQuantity).GreaterThanOrEqualTo(1).WithMessage("Ticket quantity min:1 max:100 000");
       //     RuleFor(x => x.TicketQuantity).LessThanOrEqualTo(100000).WithMessage("Ticket quantity min:1 max:100 000");

            //Day
      //      RuleFor(x => x.Day).NotEmpty().WithMessage("Start Date is required");

            //Month
      //      RuleFor(x => x.Month).NotEmpty().WithMessage("Start Date is required");

            //Year
      //      RuleFor(x => x.Year).NotEmpty().WithMessage("Start Date is required");

            //Hour
          //  RuleFor(x => x.Hour).NotEmpty().WithMessage("Start Hour is required");

            //Minute
        //    RuleFor(x => x.Minute).NotEmpty().WithMessage("Start Hour is required");

            //Only for Adult

            //RuleFor(x => x.OnlyForAdults).NotEmpty().WithMessage("It's important to specify this field");

            //Street
            //RuleFor(x => x.Street).NotEmpty().WithMessage("Full Adress is required");
            //RuleFor(x => x.Street).Matches(@"[A-Za-z0-9]+$").WithMessage("Street's field pass only letters and digits");

            ////HouseNumber
            //RuleFor(x => x.HouseNumber).NotEmpty().WithMessage("Full Adress is required");

            ////City
            //RuleFor(x => x.City).NotEmpty().WithMessage("Full Adress is required");
            //RuleFor(x => x.City).Matches(@"^[a-zA-Z]+$").WithMessage("This field pass only letters");

            ////Postal Code
            //RuleFor(x => x.PostalCode).Matches(@"^[0-9-]*$").WithMessage("Only digits and '-'");
            //RuleFor(x => x.PostalCode).NotEmpty().WithMessage("Full adress is required");

            ////Country
            //RuleFor(x => x.Country).NotEmpty().WithMessage("Full adress is required");
            //RuleFor(x => x.Country).Matches(@"^[a-zA-Z]+$").WithMessage("Only letters");

        }
    }
}
