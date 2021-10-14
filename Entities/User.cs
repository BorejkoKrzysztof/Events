using Events.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Entities
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName ="date")]
        public DateTime DateOfBirth { get; set; }


        public Sex? Sex { get; set; }

        [Required]
        public Adress Adress { get; set; }

        //[Required]
#nullable enable
        public List<Ticket>? Tickets { get; set; }

        //[Required]
        public List<Comment>? Comments { get; set; }
#nullable disable

        //[Required]
        //public int AccountId { get; set; }

        [Required]
        public List<Participant> Participant { get; set; }
    }
}
