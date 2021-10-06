using Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.interfaces
{
    public interface IEventRepository
    {
        void CreateEvent(CreateViewModel createdEvent);

        List<EventDTO> GetEventsList();

        List<EventDTO> GetEventsListFromCity(string city);

        EventDTO GetSpecificEvent(int id);

    }
}
