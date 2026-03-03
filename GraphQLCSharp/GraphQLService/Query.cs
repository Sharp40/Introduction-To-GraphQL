using GraphQLCSharp.Data;
using GraphQLCSharp.Models;

namespace GraphQLCSharp.GraphQLService;

public class Query
{
    [UsePaging(MaxPageSize = 50)]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Animal> GetAnimals([Service] AnimalDbContext animalDbContext) => 
        animalDbContext.Animals.OrderBy(animal => animal.Id); 
}
