using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
  public class AnimalsController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      List<Animal> allAnimals = Animal.GetAll();
      return View(allAnimals);
    }
  }
}
