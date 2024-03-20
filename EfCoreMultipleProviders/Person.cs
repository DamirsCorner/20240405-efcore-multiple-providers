using System.ComponentModel.DataAnnotations;

namespace EfCoreMultipleProviders;

public class Person(string firstName, string lastName)
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; } = firstName;

    [MaxLength(50)]
    public string LastName { get; set; } = lastName;
}
