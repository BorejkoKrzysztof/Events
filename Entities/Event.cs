using Events.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Entities
{
    public class Event
    {

        public Event()
        {

        }

        public Event(string name, EventType eventType, decimal? ticketPrice, Currency? currency, int ticketQuantity, DateTime startDate,
                        bool onlyForAdults, Adress eventAdress, User eventCreator)
        {
            Name = name;
            EventType = eventType;
            TicketPrice = ticketPrice;
            Currency = currency;
            TicketQuantity = ticketQuantity;
            StartDate = startDate;
            OnlyForAdults = onlyForAdults;
            EventAdress = eventAdress;
            EventCreator = eventCreator;
            PossibleTicketForBuyQuantity = ticketQuantity;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public EventType EventType { get; set; }

        [Range(0,1000000)]
        public decimal? TicketPrice { get; set; }


#nullable enable
        public Currency? Currency { get; set; }
#nullable disable

        [Range(1,int.MaxValue)]
        [Required]
        public int TicketQuantity { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public bool OnlyForAdults { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int PossibleTicketForBuyQuantity { get; set; }

        [Required]
        public Adress EventAdress { get; set; }

        public List<Participant> Participants { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Ticket> Tickets { get; set; }

        [Required]
        public User EventCreator { get; set; }

        public string? TitlePhoto { get; set; }
    }
}
