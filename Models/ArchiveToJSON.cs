using Events.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Models
{
    public class archiveToJSON
    {
        public List<Account> Accounts { get; set; }
        public List<Adress> Adresses { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Event> Events { get; set; }
        public List<Participant> Participants { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<User> Users { get; set; }
    }
}
