using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Entities
{
    public class Adress
    {

        public Adress()
        {

        }

        public Adress(string street, string houseNumber, string city, string postalCode, string country)
        {
            Street = street;
            HouseNumber = houseNumber;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Street { get; set; }

#nullable enable
        public string? HouseNumber { get; set; }
#nullable disable

        [Required]
        public string City { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Country { get; set; }

        [ForeignKey("Event")]
        public int? EventId { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
    }
}
