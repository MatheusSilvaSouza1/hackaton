using Bogus;
using Bogus.DataSets;
using Domain;

namespace TechChallenge.Tests.Entitiy;

public class MedicoBuilder
{
    // public static MedicoDTO Build()
    // {
    //     var contact = new Faker<MedicoDTO>()
    //         .RuleFor(c => c.Name, (f) => f.Person.FullName)
    //         .RuleFor(u => u.Phone, f => string.Concat(f.Random.Int(10, 99), f.Phone.PhoneNumber("9########"))
    //             .Replace("!", $"{f.Random.Int(min: 1, max: 9)}"))
    //         .RuleFor(c => c.Email, (f) => f.Internet.Email(f.Person.FullName));

    //     return contact;
    // }

    // public static MedicoUpdateDTO BuildUpdateDto()
    // {
    //     var contact = new Faker<MedicoUpdateDTO>()
    //         .RuleFor(c => c.Name, (f) => f.Person.FullName)
    //         .RuleFor(u => u.Phone, f => string.Concat(f.Random.Int(10, 99), f.Phone.PhoneNumber("9########")))
    //         .RuleFor(c => c.Email, (f) => f.Internet.Email(f.Person.FullName));

    //     return contact;
    // }

    // public static MedicoDTO WrongBuild()
    // {
    //     var contact = new Faker<MedicoDTO>()
    //         .RuleFor(c => c.Name, (f) => f.Person.FullName)
    //         .RuleFor(u => u.Phone, f => string.Concat(f.Random.Int(10, 99), f.Phone.PhoneNumber("9#####")))
    //         .RuleFor(c => c.Email, (f) => f.Internet.Email(f.Person.FullName));

    //     return contact;
    // }
    // public static MedicoDTO WrongBuildDDD()
    // {
    //     var contact = new Faker<MedicoDTO>()
    //         .RuleFor(c => c.Name, (f) => f.Person.FullName)
    //         .RuleFor(u => u.Phone, f => string.Concat("AA", f.Phone.PhoneNumber("9#####")))
    //         .RuleFor(c => c.Email, (f) => f.Internet.Email(f.Person.FullName));

    //     return contact;
    // }

}
