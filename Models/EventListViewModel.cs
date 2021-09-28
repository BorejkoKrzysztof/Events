using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Models.DTOs
{
    public class EventListViewModel
    {
        public List<EventDTO> events;

        [BindProperty(SupportsGet = true)]
        public string City { get; set; }

        public IFormFile TitlePhoto { get; set; }

        
    }
}
