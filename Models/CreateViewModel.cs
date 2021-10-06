using Events.enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Models
{
    public class CreateViewModel
    {
        public string Name { get; set; }


        [Required(ErrorMessage = "Event Type is required fieldddd")]
        public EventType EventType { get; set; }

        
        public decimal? TicketPrice { get; set; }
        

        public Currency? Currency { get; set; }


        [Required(ErrorMessage = "Ticket quantity is required")]
        [Range(1, 1000000, ErrorMessage = "Ticket quantity min:1 max:100 000")]
        public int TicketQuantity { get; set; }


        [Required(ErrorMessage = "Start Date is required")]
        public int Day { get; set; }


        [Required(ErrorMessage = "Start Date is required")]
        public int Month { get; set; }
        
        
        [Required(ErrorMessage = "Start Date is required")]
        public int Year { get; set; }


        [Required(ErrorMessage = "Start Hour is required")]
        public int Hour { get; set; }


        [Required(ErrorMessage = "Start Hour is required")]
        public int Minute { get; set; }


        [Required(ErrorMessage = "It's important to specify this field")]
        [Range(0, 1, ErrorMessage = "BLAD")]
        public bool OnlyForAdults { get; set; }


        [Required(ErrorMessage = "Full Adress is required")]
        [RegularExpression(@"[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ0-9]+$")]
        public string Street { get; set; }


        [Required(ErrorMessage = "Full Adress is required")]
        public string HouseNumber { get; set; }


        [Required(ErrorMessage = "Full Adress is required")]
        [RegularExpression(@"^[a-zżźćńółęąśŻŹĆĄŚĘŁÓŃA-Z]+$", ErrorMessage = "This field pass only letters")]
        public string City { get; set; }


        [Required(ErrorMessage = "Full Adress is required")]
        [RegularExpression(@"^[0-9-]*$", ErrorMessage = "Only digits and '-'")]
        public string PostalCode { get; set; }


        [Required(ErrorMessage = "Full Adress is required")]
        [RegularExpression(@"^[a-zżźćńółęąśŻŹĆĄŚĘŁÓŃA-Z]+$", ErrorMessage = "This field pass only letters")]
        public string Country { get; set; }

#nullable enable
        public IFormFile? TitlePhoto { get; set; }
#nullable disable
    }
}
