using AutoMapper;
using Events.Database;
using Events.Entities;
using Events.interfaces;
using Events.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Events.services
{
    public class EventRepository : IEventRepository
    {

        EventDbContext _dbContext;
        IMapper _mapper;
        IWebHostEnvironment _webHostEnvironment;

        public EventRepository(EventDbContext dbContext, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _webHostEnvironment = hostEnvironment;
        }


        public bool CreateEvent(CreateViewModel createdEvent)
        {
            //var eventItem = _mapper.Map<Event>(createdEvent.Event);

            //_dbContext.Events.Add(eventItem);
            //_dbContext.SaveChanges();

            //var eventId = _dbContext.Events.FirstOrDefault(x => x.Name == createdEvent.Event.Name).Id;

            //string uniqueFileName = null;

            //if (createdEvent.TitlePhoto != null)
            //{
            //    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, $"images/eventsimgs/{eventId}");
            //    uniqueFileName = Guid.NewGuid().ToString() + " " + createdEvent.TitlePhoto.FileName;
            //    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            //    using (var fileStream = new FileStream(filePath, FileMode.Create))
            //    {
            //        createdEvent.TitlePhoto.CopyTo(fileStream);
            //    }

            //    _dbContext.Events.FirstOrDefault(x => x.Name == createdEvent.Event.Name).TitlePhoto = uniqueFileName;
            //    _dbContext.SaveChanges();
            //}


            return true;
        }

        public List<EventDTO> GetEventsList()
        {
            var events = _dbContext.Events.Include(r => r.EventAdress);

            var eventsDTO = _mapper.Map<List<EventDTO>>(events);



            return eventsDTO;
        }

        public List<EventDTO> GetEventsListFromCity(string city)
        {
            var events = (from e in _dbContext.Events
                         join a in _dbContext.Adresses
                         on e.Id equals a.EventId
                         where a.City == city
                         select e).Include(r => r.EventAdress).ToList();

            var eventsDTO = _mapper.Map<List<EventDTO>>(events);



            return eventsDTO;
        }

        public EventDTO GetSpecificEvent(int id)
        {
            var specificEvent = _dbContext.Events.FirstOrDefault(x => x.Id == id);

            var eventDTO = _mapper.Map<EventDTO>(specificEvent);

            return eventDTO;
        }



    }
}
