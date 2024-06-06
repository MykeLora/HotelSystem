﻿using Hotel.Infraestructure.Interfaces;
using Hotel.Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriaController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        // GET: api/<CategoriaController>
        [HttpGet]
        public IActionResult Get()
        {
            var categories = this.categoryRepository.GetEntities();
            return Ok(categories);
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}