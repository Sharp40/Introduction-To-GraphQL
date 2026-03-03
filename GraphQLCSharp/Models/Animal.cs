namespace GraphQLCSharp.Models;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Species { get; set; } = default!;
    public int Age { get; set; }
}
