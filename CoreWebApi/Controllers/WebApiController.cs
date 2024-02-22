using CoreWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiController : ControllerBase
    {
        //public static List<WebApi> heroes = new List<WebApi>
        //{
                //new WebApi 
                //{
                //    Id = 1,
                //    Name = "Siper Man",
                //    FirstName = "Peter",
                //    LastName = "Parker",
                //    Place = "NewYork"
                //},

                // new WebApi
                //{
                //    Id = 2,
                //    Name = "Iron Man",
                //    FirstName = "Tony",
                //    LastName = "Stark",
                //    Place = "Long IsLand"
                //}
        //};

        private readonly DataContext context;
        public WebApiController(DataContext context) // Injecting DataContext
        {
            this.context = context;
        }

        [HttpGet] 
        public async Task<ActionResult<List<WebApi>>> Get()
        {
            

            return Ok(await context.WebApis.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApi>> Get(int id)
        {

            //var hero = heroes.Find(h => h.Id == id);
            var hero = await context.WebApis.FindAsync(id);

            if (hero == null)
                return BadRequest("Hero not Found");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<WebApi>>> AddHero(WebApi hero)
        {
           
                
            context.WebApis.Add(hero);
            await context.SaveChangesAsync();
            return Ok(await context.WebApis.ToListAsync());
        
        }

        [HttpPut]
        public async Task<ActionResult<List<WebApi>>> UpdateHero(WebApi request)
        {
            var hero = await context.WebApis.FindAsync(request.Id);

            if (hero == null)
                return BadRequest("Hero not Found");

            // Update only the properties that are not null in the incoming request
            if (request.Name != null)
                hero.Name = request.Name;

            if (request.FirstName != null)
                hero.FirstName = request.FirstName;

            if (request.LastName != null)
                hero.LastName = request.LastName;

            if (request.Place != null)
                hero.Place = request.Place;

            await context.SaveChangesAsync();

            return Ok(await context.WebApis.ToListAsync());
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<List<WebApi>>> Delete(int id)
        {

            var hero = await context.WebApis.FindAsync(id);

            if (hero == null)
                return BadRequest("Hero not Found");

            context.WebApis.Remove(hero);
            await context.SaveChangesAsync();
            return Ok(await context.WebApis.ToListAsync());
        }
    }
}
