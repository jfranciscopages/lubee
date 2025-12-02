using lubee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lubee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private static readonly List<Listing> Listings = new();
        private static int _currentId = 1;

        [HttpGet]
        public ActionResult<IEnumerable<Listing>> GetAll()
        {
            return Ok(Listings);
        }

        [HttpGet("{id}")]
        public ActionResult<Listing> GetById(int id)
        {
            var listing = Listings.FirstOrDefault(l => l.Id == id);

            if (listing == null)
                return NotFound();

            return Ok(listing);
        }

        [HttpPost]
        public ActionResult<Listing> Create(Listing listing)
        {
            listing.Id = _currentId++;
            Listings.Add(listing);

            return CreatedAtAction(nameof(GetById), new { id = listing.Id }, listing);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Listing updated)
        {
            var listing = Listings.FirstOrDefault(l => l.Id == id);

            if (listing == null)
                return NotFound();

            listing.PropertyType = updated.PropertyType;
            listing.OperationType = updated.OperationType;
            listing.Description = updated.Description;
            listing.Rooms = updated.Rooms;
            listing.SquareMeters =  updated.SquareMeters;
            listing.Age = updated.Age;
            listing.Coordinates = updated.Coordinates;
            listing.Images = updated.Images;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var listing = Listings.FirstOrDefault(l => l.Id == id);

            if (listing == null)
                return NotFound();

            Listings.Remove(listing);

            return NoContent();
        }
    }
}
