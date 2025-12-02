using lubee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lubee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private static readonly List<Listing> Listings = new()
        {
            new Listing
            {
                Id = 1,
                PropertyType = "Apartment",
                OperationType = "Rent",
                Description = "Bright 2-room apartment in Palermo",
                Rooms = 2,
                SquareMeters = 45,
                Age = 5,
                Coordinates = "-34.5760,-58.4250",
                Images = new List<string>
                {
                    "https://travelingwithsunscreen.com/wp-content/uploads/2019/04/optimized-sch9.jpg",
                    "https://hosttools.com/wp-content/uploads/clay-banks-mQmDscIIQfs-unsplash-1.webp"
                }
            },
            new Listing
            {
                Id = 2,
                PropertyType = "House",
                OperationType = "Sale",
                Description = "Spacious family house with garden",
                Rooms = 4,
                SquareMeters = 120,
                Age = 20,
                Coordinates = "-34.6000,-58.3800",
                Images = new List<string>
                {
                    "https://a0.muscache.com/im/pictures/miso/Hosting-1169255324934560934/original/3dc03c46-e054-4d97-97b1-2063dadc6583.jpeg?im_w=720"
                }
            },
            new Listing
            {
                Id = 3,
                PropertyType = "Studio",
                OperationType = "Rent",
                Description = "Affordable studio close to downtown",
                Rooms = 1,
                SquareMeters = 28,
                Age = 10,
                Coordinates = "-34.6037,-58.3816",
                Images = new List<string>
                {
                    "https://a0.muscache.com/im/pictures/airflow/Hosting-653692932326416808/original/2ff1decb-be08-4c85-b7ec-2f32143cd5e8.jpg?im_w=720",
                    "https://a0.muscache.com/im/pictures/airflow/Hosting-653692932326416808/original/2ff1decb-be08-4c85-b7ec-2f32143cd5e8.jpg?im_w=720"
                }
            },
            new Listing
            {
                Id = 4,
                PropertyType = "Loft",
                OperationType = "Rent",
                Description = "Modern loft in Recoleta, close to cafes and parks",
                Rooms = 2,
                SquareMeters = 65,
                Age = 3,
                Coordinates = "-34.5881,-58.3935",
                Images = new List<string>
                {
                    "https://cf.bstatic.com/xdata/images/hotel/max300/258321068.jpg?k=398e198abab1951a1fe45ee49ea6ac0abb97673daf7950f30dc2718c6dba15e1&o=",
                    "https://a0.muscache.com/im/pictures/miso/Hosting-51497079/original/ae97055a-1fbd-4d6e-996e-ced13a3da56b.jpeg?im_w=720"
                }
            }
        };

        private static int _currentId = 5;


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
