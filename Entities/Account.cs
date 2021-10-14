
using Events.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Entities
{
    public class Account
    {
        [Required]
        public int Id { get; set; }

        public long? BankAccountNumber { get; set; }

        public long? PayPalAccountNumber { get; set; }

      //  [Required]
        public User AccountOwner { get; set; }

        [ForeignKey("AccountOwner")]
        public int? AccountOwnerId { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string EmailAdress { get; set; }
        [Required]
        //[MaxLength(50)]
        public string PasswordHash { get; set; }

        [Required]
        public RoleType Role { get; set; }
    }
}
