using System.Reflection;

namespace Hw4.Exercise0;

public static class PersonValidator
{
    public static PersonValidationResult Validate(Person? person)
    {
        if (person == null)
            return new PersonValidationResult() { IsValid = false, ErrorMessage = "Person can't be null" };

        var type = typeof(Person);
        var attributes = type.GetCustomAttributes<IsValidAttribute>();

        foreach (var attr in attributes)
        {
            if (string.IsNullOrWhiteSpace(person.Name))
                return new PersonValidationResult() { IsValid = false, ErrorMessage = "Person Name is required" };
            else if (person.Age > attr.MaxAge || person.Age < attr.MinAge)
                return new PersonValidationResult() { IsValid = false, ErrorMessage = "Person Age is out of range" };
            else if (person.Weight > attr.MaxWeight || person.Weight < attr.MinWeight)
                return new PersonValidationResult() { IsValid = false, ErrorMessage = "Person Weight is out of range" };

        }
        return new PersonValidationResult() { IsValid = true, ErrorMessage = "Succes" };

    }
}
