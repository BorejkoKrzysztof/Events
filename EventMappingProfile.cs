using AutoMapper;
using Events.Entities;
using Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events
{
    public class EventMappingProfile : Profile
    {
        public EventMappingProfile()
        {
            CreateMap<RegisterInfoDTO, Account>();

            CreateMap<Event, EventDTO>()
                .ForMember(x => x.CreatorFirstName, c => c.MapFrom(j => j.EventCreator.FirstName))
                .ForMember(x => x.CreatorLastName, c => c.MapFrom(j => j.EventCreator.LastName))
                .ForMember(x => x.Street, c => c.MapFrom(j => j.EventAdress.Street))
                .ForMember(x => x.HouseNumber, c => c.MapFrom(j => j.EventAdress.HouseNumber))
                .ForMember(x => x.PostalCode, c => c.MapFrom(j => j.EventAdress.PostalCode))
                .ForMember(x => x.City, c => c.MapFrom(j => j.EventAdress.City))
                .ForMember(x => x.Country, c => c.MapFrom(j => j.EventAdress.Country));
 
        }
    }
}
