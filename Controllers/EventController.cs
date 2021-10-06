using Events.interfaces;
using Events.Models;
using Events.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Controllers
{
    public class EventController : Controller
    {

        IEventRepository _service;


        public EventController(IEventRepository service)
        {
            _service = service;
        }



        public IActionResult Index([FromQuery] string? city)
        {
            var pageModel = new EventListViewModel();

            pageModel.City = city;
            if (string.IsNullOrWhiteSpace(pageModel.City)) pageModel.events = _service.GetEventsList();
            else pageModel.events = _service.GetEventsListFromCity(city);

            return View(pageModel);
        }


        public IActionResult Event(int id)
        {
            var specificEvent = _service.GetSpecificEvent(id);


            return View(specificEvent);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(CreateViewModel createdEvent)
        {
            if (ModelState.IsValid)
            {
                _service.CreateEvent(createdEvent);

                return View("~/Views/Home/Index.cshtml");
            }
            return View();
        }
    }
}
