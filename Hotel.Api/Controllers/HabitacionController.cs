using Hotel.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        private readonly IHabitacionRepository habitacionRepository;

        public HabitacionController(IHabitacionRepository habitacionRepository)
        {
            this.habitacionRepository = habitacionRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var habitacion = this.habitacionRepository.GetEntities().ToList();

            return Ok(habitacion);
        
        }

        // GET api/<HabitacionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HabitacionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HabitacionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HabitacionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
