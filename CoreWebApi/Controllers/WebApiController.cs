using Microsoft.AspNetCore.Mvc;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiController : ControllerBase
    {
        public static List<WebApi> heroes = new List<WebApi>
        {
                new WebApi 
                {
                    Id = 1,
                    Name = "Siper Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "NewYork"
                },

                 new WebApi
                {
                    Id = 2,
                    Name = "Iron Man",
                    FirstName = "Tony",
                    LastName = "Stark",
                    Place = "Long IsLand"
                }
        };

        [HttpGet] 
        public async Task<ActionResult<List<WebApi>>> Get()
        {
            

            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApi>> Get(int id)
        {

            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Hero not Found");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<WebApi>>> AddHero( WebApi hero )
        {

            heroes.Add(hero);
            return Ok(heroes);
        }
    }
}
