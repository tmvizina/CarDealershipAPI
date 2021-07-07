using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarDealership.Models;

namespace CarDealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CardealershipContext _context;

        public CarsController(CardealershipContext context)
        {
            _context = context;
        }

        CardealershipContext db = new CardealershipContext();

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await _context.Cars.ToListAsync();
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return car;
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }

        [HttpGet]
        [Route("Search/model={model}")]
        public List<Car> SearchbyModel(string model)
        {

            List<Car> Carslist = db.Cars.ToList();
            //This assumes that there is only of each model type
            List<Car> output = Carslist.Where(x => x.Model == model).ToList();
            return output;

        }

        [HttpGet]
        [Route("Search/year={year}")]
        public List<Car> SearchbyYear(int year)
        {

            List<Car> Carslist = db.Cars.ToList();
            //This assumes that there is only of each model type
            List<Car> output = Carslist.Where(x => x.Year == year).ToList();
            return output;

        }

        [HttpGet]
        [Route("Search/newerthanyear={year}")]
        public List<Car> SearchbyNewerthanYear(int year)
        {

            List<Car> Carslist = db.Cars.ToList();
            //This assumes that there is only of each model type
            List<Car> output = Carslist.Where(x => x.Year > year).ToList();
            return output;

        }

        [HttpGet]
        [Route("Search/olderrthanyear={year}")]
        public List<Car> SearchbyOlderthanYear(int year)
        {

            List<Car> Carslist = db.Cars.ToList();
            //This assumes that there is only of each model type
            List<Car> output = Carslist.Where(x => x.Year < year).ToList();
            return output;

        }


        [HttpGet]
        [Route("Search/make={make}")]
        public List<Car> SearchbyMake(string make)
        {

            List<Car> Carslist = db.Cars.ToList();
            //This assumes that there is only of each model type
            List<Car> output = Carslist.Where(x => x.Make == make).ToList();
            return output;

        }

        [HttpGet]
        [Route("Search/make={make}/year={year}")]
        public List<Car> SearchbyMakeandYear(string make, int year)
        {
            List<Car> Carslist = db.Cars.ToList();
            List<Car> output = Carslist.Where(x => x.Make == make&& x.Year == year).ToList();
  
            return output;
        }

        [HttpGet]
        [Route("Search/make={make}/oryear={year}")]
        public List<Car> SearchbyMakeorYear(string make, int year)
        {
            List<Car> Carslist = db.Cars.ToList();
            List<Car> filteredbymakeoryear = Carslist.Where(x => x.Make == make||x.Year == year).ToList();
            return filteredbymakeoryear;
        }

        [HttpGet]
        [Route("Search/make={make}/color={color}")]
        public List<Car> SearchbyMakeandColor(string make, string color)
        {
            List<Car> Carslist = db.Cars.ToList();
            List<Car> filteredbymakethencolor = Carslist.Where(x => x.Make == make && x.Color == color).ToList();
            
            return filteredbymakethencolor;
        }


        [HttpGet]
        [Route("Search/color={color}")]
        public List<Car> SearchbyColor(string color)
        {

            List<Car> Carslist = db.Cars.ToList();
            //This assumes that there is only of each model type
            List<Car> output = Carslist.Where(x => x.Color == color).ToList();
            return output;

        }


    }
}
