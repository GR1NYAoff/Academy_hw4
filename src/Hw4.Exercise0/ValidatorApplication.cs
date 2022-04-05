using Common;

namespace Hw4.Exercise0;

public sealed class ValidatorApplication
{
    /// <summary>
    /// Runs application.
    /// </summary>
    public ReturnCode Run(string[] args)
    {
        // TODO: create a person object from passed `args`
        for (var i = 0; i < args.Length; i++)
        {
            if (string.IsNullOrEmpty(args[i]))
                return ReturnCode.InvalidArgs;

        }

        var ageParse = int.TryParse(args[1], out var age);
        var weightParse = double.TryParse(args[2], out var weight);

        if (!ageParse && !weightParse)
            return ReturnCode.InvalidArgs;

        var person = new Person(args[0], age, weight);

        // validate
        var validationResult = PersonValidator.Validate(person);

        // and log validation result
        Console.WriteLine("Person {0} validation result is: {1}", person, validationResult);

        return validationResult.IsValid ? ReturnCode.Success : ReturnCode.InvalidArgs;
    }
}
