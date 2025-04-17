namespace yadegar.Domain.Model;

public class Translator : IEquatable<Translator>
{
    public Translator(string firstName, string lastName)
    {
        NameValidator(firstName, lastName);
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public string FullName => $"{FirstName} {LastName}";

    private static void NameValidator(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name cannot be null or empty.", nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name cannot be null or empty.", nameof(lastName));
        if (firstName.Length < 2)
            throw new ArgumentException("First name must be at least 2 characters long.", nameof(firstName));
        if (lastName.Length < 2)
            throw new ArgumentException("Last name must be at least 2 characters long.", nameof(lastName));
        if (firstName.Length > 50)
            throw new ArgumentException("First name cannot exceed 50 characters.", nameof(firstName));
        if (lastName.Length > 50)
            throw new ArgumentException("Last name cannot exceed 50 characters.", nameof(lastName));
        if (!char.IsUpper(firstName[0]))
            throw new ArgumentException("First name must start with an uppercase letter.", nameof(firstName));
        if (!char.IsUpper(lastName[0]))
            throw new ArgumentException("Last name must start with an uppercase letter.", nameof(lastName));
    }

    public override bool Equals(object? obj)
    {
        return obj is Translator translator &&
               FirstName == translator.FirstName &&
               LastName == translator.LastName;
    }

  public bool Equals(Translator? other)
  {
    throw new NotImplementedException();
  }

  public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName);
    }

    public override string ToString() => FullName;

}