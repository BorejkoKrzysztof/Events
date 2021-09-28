using Events.enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Models
{
    public class CreateViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(35, ErrorMessage = "Name's max length is 35")]
        [MinLength(3, ErrorMessage = "Name's min length is 3")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Event Type is required field")]
        public EventType EventType { get; set; }


        [Required(ErrorMessage = "Ticket price is required, if event's FREE give 0")]
        [Range(0, 250000, ErrorMessage = "Min Ticket price equals 0 and Max equals 250 000")]
        public decimal TicketPrice { get; set; }


        [Required(ErrorMessage = "Currency is required")]
        public Currency Currency { get; set; }


        [Required(ErrorMessage = "Ticket quantity is required")]
        [Range(1, 1000000, ErrorMessage = "Ticket quantity min:1 max:100 000")]
        public int TicketQuantity { get; set; }


        [Required(ErrorMessage = "Start Date is required")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Wrong Event's Day")]
        public int Day { get; set; }


        [Required(ErrorMessage = "Start Date is required")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Wrong Event's Month")]
        public int Month { get; set; }
        
        
        [Required(ErrorMessage = "Start Date is required")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Wrong Event's Year")]
        public int Year { get; set; }


        [Required(ErrorMessage = "Start Hour is required")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Wrong Event's Hour")]
        public int Hour { get; set; }


        [Required(ErrorMessage = "Start Hour is required")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Wrong Event's Minute")]
        public int Minute { get; set; }


        [Required(ErrorMessage = "It's important to specify this field")]
        [Range(0,1, ErrorMessage ="BLAD")]
        public bool OnlyForAdults { get; set; }


        public int PossibleTicketForBuyQuantity { get; set; }


        [Required(ErrorMessage = "Full Adress is required")]
        [RegularExpression(@"[A-Za-z0-9]+$")]
        public string Street { get; set; }


        [Required(ErrorMessage = "Full Adress is required")]

        public string HouseNumber { get; set; }


        [Required(ErrorMessage = "Full Adress is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "This field pass only letters")]
        public string City { get; set; }


        [Required(ErrorMessage = "Full Adress is required")]
        [RegularExpression(@"^[0-9-]*$", ErrorMessage = "Only digits and '-'")]
        public string PostalCode { get; set; }


        [Required(ErrorMessage = "Full Adress is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "This field pass only letters")]
        public string Country { get; set; }


        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "This field pass only letters")]
        public string CreatorFirstName { get; set; }


        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "This field pass only letters")]
        public string CreatorLastName { get; set; }

        public IFormFile TitlePhoto { get; set; }
    }
}
