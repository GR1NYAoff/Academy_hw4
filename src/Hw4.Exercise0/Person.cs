namespace Hw4.Exercise0;

[IsValid(18, 200, 40d, 200d)]
public sealed class Person
{
    [IsValid]
    public string? Name { get; set; }
    [IsValid]
    public int Age { get; set; }
    [IsValid]
    public double Weight { get; set; }
    public Person() { }
    public Person(string name, int age, double weight)
    {
        Name = name;
        Age = age;
        Weight = weight;
    }
}
