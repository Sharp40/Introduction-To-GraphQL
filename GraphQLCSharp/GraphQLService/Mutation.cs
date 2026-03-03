using GraphQLCSharp.Data;
using GraphQLCSharp.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLCSharp.GraphQLService;

public class Mutation
{
    public async Task<Animal> AddAnimal(AnimalInput input, [Service] AnimalDbContext context)
    {
        var animal = new Animal
        {
            Name = input.Name,
            Species = input.Species,
            Age = input.Age
        };

        context.Animals.Add(animal);
        await context.SaveChangesAsync();
        return animal;
    }


    public async Task<Animal?> UpdateAnimal(int id, AnimalInput input, [Service] AnimalDbContext context)
    {
        var animal = await context.Animals.FindAsync(id);
        if (animal is null) return null;

        animal.Name = input.Name;
        animal.Species = input.Species;
        animal.Age = input.Age;

        await context.SaveChangesAsync();
        return animal;
    }

    public async Task<bool> DeleteAnimal(int id, [Service] AnimalDbContext context)
    {
        var animal = await context.Animals.FindAsync(id);
        if (animal is null) return false;

        context.Animals.Remove(animal);
        await context.SaveChangesAsync();
        return true;
    }
}
