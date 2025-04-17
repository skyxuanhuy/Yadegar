namespace yadegar.Domain.Model;

public class Author : IEquatable<Author>
{
    public Author(string firstName, string lastName)
    {
        NameValidator(firstName, lastName);

        FirstName = firstName.Trim();
        LastName = lastName.Trim();
    }

    // یه سازنده خالی private هم برای EF Core لازمه
    private Author()
    {
        FirstName = null!;
        LastName = null!;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public string FullName => $"{FirstName} {LastName}";

    private static void NameValidator(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name cannot be empty", nameof(firstName));

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name cannot be empty", nameof(lastName));

        if (firstName.Length > 50)
            throw new ArgumentException("First name is too long", nameof(firstName));

        if (lastName.Length > 50)
            throw new ArgumentException("Last name is too long", nameof(lastName));

    }

    public override bool Equals(object? obj)
    {
        return obj is Author author &&
               FirstName == author.FirstName &&
               LastName == author.LastName;
    }

    public bool Equals(Author? other)
    {
        throw new NotImplementedException();
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName);
    }
    public override string ToString() => FullName;

}