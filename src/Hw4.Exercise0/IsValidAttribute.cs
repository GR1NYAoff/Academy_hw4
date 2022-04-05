namespace Hw4.Exercise0;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
internal class IsValidAttribute : Attribute
{
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public double MinWeight { get; set; }
    public double MaxWeight { get; set; }
    public IsValidAttribute() { }
    public IsValidAttribute(int minAge, int maxAge, double minWeight, double maxWeight)
    {
        MinAge = minAge;
        MaxAge = maxAge;
        MinWeight = minWeight;
        MaxWeight = maxWeight;
    }
}
