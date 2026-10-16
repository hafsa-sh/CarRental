using CarRentalApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    public class CarsController : Controller
    {
        private static List<Car> availableCars = new List<Car>
        {
        new Car { Id = 1, Name = "Alto", PricePerDay = 3000 },
        new Car { Id = 2, Name = "Corolla", PricePerDay = 6000 },
        new Car { Id = 3, Name = "Civic", PricePerDay = 8000 }
        };
        private static List<Car> bookedCars = new List<Car>();
        public IActionResult index()
        {
            return View(availableCars);
        }
        public IActionResult book(int Id)
        {
            for (int i = 0; i < availableCars.Count(); i++)
            {
                if (availableCars[i].Id == Id)
                {
                    var car = availableCars[i];
                    availableCars.Remove(car);
                    bookedCars.Add(car);
                    return RedirectToAction("booked");
                }
            }
            return RedirectToAction("index");
        }
        public IActionResult booked()
        {
            return View(bookedCars);
        }
    }
}
