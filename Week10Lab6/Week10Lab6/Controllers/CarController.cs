using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week10Lab6.Models;

namespace Week10Lab6.Controllers
{

    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private readonly CarContext _context;
        public CarController(CarContext context)
        {
            _context = context;
            if (_context.Cars.Count() == 0)
            {
                _context.Cars.Add(new Car { id = 0, color = "red", country = "Belgium", model = "Z234", year = 1978, ownerId = 3 });
                _context.SaveChanges();
            }
        }
        [HttpGet]
        public IEnumerable<Car> GetAll()
        {
            return _context.Cars.ToList();
        }
        [HttpGet("{id}", Name = "GetCar")]
        public IActionResult GetCarById(int id)
        {
            var item = _context.Cars.FirstOrDefault(x => x.id == id);
            if (item != null)
            {
                return new ObjectResult(item);
            }
            return RedirectToAction("GetAll", "Car");
        }
        [HttpPost]
        public IActionResult CreateCar([FromBody] Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            _context.Cars.Add(car);
            _context.SaveChanges();
            return CreatedAtRoute("GetCar", new { id = car.id }, car);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, [FromBody] Car car)
        {
            if (car.id != id || car == null)
            {
                return BadRequest();
            }
            var item = _context.Cars.FirstOrDefault(c => c.id == id);
            if (item == null)
            {
                return BadRequest();
            }
            item.model = car.model;
            item.ownerId = car.ownerId;
            item.country = car.country;
            item.color = car.color;
            item.year = car.year;

            _context.Cars.Update(item);
            _context.SaveChanges();

            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = _context.Cars.FirstOrDefault(c => c.id == id);
            if (car == null)
            {
                return NotFound();
            }
            _context.Cars.Remove(car);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}