using System;
using System.Collections.Generic;
using WebApplication1.Models

namespace WebApplication1.Repositories
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> GetAnimals(string orderBy);
        void AddAnimal(Animal animal);
        void UpdateAnimal(Animal animal);
        void DeleteAnimal(int idAnimal);
    }
}
