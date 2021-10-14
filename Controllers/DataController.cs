using Events.interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Controllers
{
    public class DataController : Controller
    {

        IDataRepository _service;

        public DataController(IDataRepository service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateAccounts()
        {
            _service.CreateDefaultsAccounts();

            return RedirectToAction("Index", "Data");
        }

        public IActionResult DeleteAccounts()
        {
            var result = _service.DeleteAccounts();
            if (result == true)
                return RedirectToAction("Index", "Data");

            return View("~/Views/Data/FirstDeleteEvents.cshtml");
        }

        public IActionResult CreateEvents()
        {
            var result = _service.CreateDefaultCollectionEvents();
            if (result == true)
                return RedirectToAction("Index", "Data");

            return View("~/Views/Data/FirstCreateAccounts.cshtml");
        }

        public IActionResult DeleteEvents()
        {
            _service.DeleteCollectionOfEvents();

            return RedirectToAction("Index", "Data");
        }

        public IActionResult SaveDataToJSON()
        {
            _service.SaveDatasToJSON();

            return RedirectToAction("Index", "Data");
        }

        public IActionResult ReadDataFromJSON()
        {
            _service.ReadDatasFromJSON();

            return RedirectToAction("Index", "Data");
        }
    }
}
