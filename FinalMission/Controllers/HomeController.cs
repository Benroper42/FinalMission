using System.Diagnostics;
using FinalMission.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalMission.Controllers
{
    public class HomeController : Controller
    {
        private IFinalRepository _repo;
        public HomeController(IFinalRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Entertainers()
        {
            var Entertainers = _repo.Entertainers
               .ToList();

            return View(Entertainers);
        }

        [HttpGet]
        public IActionResult AddEnt()
        {

            return View(new Entertainer());
        }

        [HttpPost]
        public IActionResult AddEnt(Entertainer response)
        {
            _repo.AddEnt(response);

            return RedirectToAction("Entertainers");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var EntDetails = _repo.GetEntertainerById(id); 
               


            return View("Details", EntDetails);
        }

        [HttpGet]
        public IActionResult EditEnt(int id)
        {
            var recordToEdit = _repo.GetEntertainerById(id);
                


            return View("AddEnt", recordToEdit);
        }

        [HttpPost]
        public IActionResult EditEnt(Entertainer updatedEntertainer)
        {
            _repo.EditEnt(updatedEntertainer);

            return RedirectToAction("Details", new { id = updatedEntertainer.EntertainerId });
        }


        [HttpGet]
        public IActionResult DeleteEnt(int id)
        {
            var recordToDelete = _repo.Entertainers
                .Single(x => x.EntertainerId == id);


            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult DeleteEnt(Entertainer entertainer)
        {
            _repo.DeleteEnt(entertainer);

            return RedirectToAction("Entertainers");
        }
    }




}

