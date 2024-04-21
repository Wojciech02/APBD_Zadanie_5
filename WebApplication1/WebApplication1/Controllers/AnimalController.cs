using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Services;
using System;
using System.Collections.Generic;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalsController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        // GET api/animals
        [HttpGet]
        public IActionResult GetAnimals([FromQuery] string orderBy = "name")
        {
            try
            {
                IEnumerable<AnimalDto> animals = _animalService.GetAnimals(orderBy);
                return Ok(animals);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/animals
        [HttpPost]
        public IActionResult AddAnimal([FromBody] AnimalDto animalDto)
        {
            try
            {
                _animalService.AddAnimal(animalDto);
                return CreatedAtAction(nameof(GetAnimals), new { id = animalDto.Id }, animalDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/animals/{idAnimal}
        [HttpPut("{idAnimal}")]
        public IActionResult UpdateAnimal(int idAnimal, [FromBody] AnimalDto animalDto)
        {
            try
            {
                _animalService.UpdateAnimal(idAnimal, animalDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/animals/{idAnimal}
        [HttpDelete("{idAnimal}")]
        public IActionResult DeleteAnimal(int idAnimal)
        {
            try
            {
                _animalService.DeleteAnimal(idAnimal);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
