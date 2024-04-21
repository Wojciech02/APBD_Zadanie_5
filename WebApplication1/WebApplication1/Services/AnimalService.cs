using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Repositories;
using System.Collections.Generic;

namespace WebApplication1.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public IEnumerable<AnimalDto> GetAnimals(string orderBy)
        {
            IEnumerable<Animal> animals = _animalRepository.GetAnimals(orderBy);


            List<AnimalDto> animalDtos = new List<AnimalDto>();
            foreach (var animal in animals)
            {
                AnimalDto animalDto = new AnimalDto
                {
                    Name = animal.Name,
                    Description = animal.Description,
                    Category = animal.Category,
                    Area = animal.Area
                };
                animalDtos.Add(animalDto);
            }

            return animalDtos;
        }

        public void AddAnimal(AnimalDto animalDto)
        {

            Animal animal = new Animal
            {
                Name = animalDto.Name,
                Description = animalDto.Description,
                Category = animalDto.Category,
                Area = animalDto.Area
            };

            _animalRepository.AddAnimal(animal);
        }

        public void UpdateAnimal(int idAnimal, AnimalDto animalDto)
        {

            Animal animal = new Animal
            {
                IdAnimal = idAnimal,
                Name = animalDto.Name,
                Description = animalDto.Description,
                Category = animalDto.Category,
                Area = animalDto.Area
            };

            _animalRepository.UpdateAnimal(animal);
        }

        public void DeleteAnimal(int idAnimal)
        {
            _animalRepository.DeleteAnimal(idAnimal);
        }
    }
}