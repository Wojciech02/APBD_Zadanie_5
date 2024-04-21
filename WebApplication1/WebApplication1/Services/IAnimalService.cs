using WebApplication1.DTO;
using System.Collections.Generic;

namespace WebApplication1.Services
{
    public interface IAnimalService
    {
        IEnumerable<AnimalDto> GetAnimals(string orderBy);
        void AddAnimal(AnimalDto animalDto);
        void UpdateAnimal(int idAnimal, AnimalDto animalDto);
        void DeleteAnimal(int idAnimal);
    }
}