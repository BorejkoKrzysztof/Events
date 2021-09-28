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
        [Required]
        public int Id { get; set; }

        [Required]
        public string Street { get; set; }

        //[Required]
        public string HouseNumber { get; set; }

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
