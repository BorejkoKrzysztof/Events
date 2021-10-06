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


        public void CreateEvent(CreateViewModel createdEvent)
        {
            var eventItem = new Event(createdEvent.Name[0].ToString().ToUpper()+createdEvent.Name.Substring(1),
                                       createdEvent.EventType, createdEvent.TicketPrice, createdEvent.Currency,
                                       createdEvent.TicketQuantity,
                                       new DateTime(createdEvent.Year, createdEvent.Month, createdEvent.Day, createdEvent.Hour, createdEvent.Minute, 0),
                                       createdEvent.OnlyForAdults,
                                       new Adress(createdEvent.Street[0].ToString().ToUpper()+createdEvent.Street.Substring(1),
                                       createdEvent.HouseNumber, createdEvent.City[0].ToString().ToUpper()+createdEvent.City.Substring(1),
                                       createdEvent.PostalCode, createdEvent.Country[0].ToString().ToUpper()+createdEvent.Country.Substring(1)),
                                       _dbContext.Users.FirstOrDefault(x => x.Id == 2)); // user do poprawy


            _dbContext.Events.Add(eventItem);
            _dbContext.SaveChanges();


            if (createdEvent.TitlePhoto != null)
            {
                var eventId = _dbContext.Events.FirstOrDefault(x => x.Name == createdEvent.Name).Id;

                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, $"Images/EventsIMGs/Custom/{eventId}");
                string uniqueFileName = Guid.NewGuid().ToString() + " " + createdEvent.TitlePhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                Directory.CreateDirectory(uploadsFolder);

                using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    createdEvent.TitlePhoto.CopyTo(fileStream);
                }

                _dbContext.Events.FirstOrDefault(x => x.Name == createdEvent.Name).TitlePhoto = uniqueFileName;
                _dbContext.SaveChanges();
            }


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
            var eventDTO = _mapper.Map<EventDTO>(_dbContext.Events.FirstOrDefault(x => x.Id == id));


            return eventDTO;
        }



    }
}
