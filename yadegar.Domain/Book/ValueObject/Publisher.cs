namespace yadegar.Domain.Model;

public sealed class Publisher : IEquatable<Publisher>
{
    private const int MIN_NAME_LENGTH = 2;
    private const int MAX_NAME_LENGTH = 100;

    public Publisher(string name)
    {
        ValidatePublisherName(name);
        Name = name.Trim();
    }

    public string Name { get; }

    private static void ValidatePublisherName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Publisher name cannot be empty", nameof(name));

        var trimmedName = name.Trim();
        
        if (trimmedName.Length < MIN_NAME_LENGTH)
            throw new ArgumentException($"Publisher name must be at least {MIN_NAME_LENGTH} characters", nameof(name));
            
        if (trimmedName.Length > MAX_NAME_LENGTH)
            throw new ArgumentException($"Publisher name cannot exceed {MAX_NAME_LENGTH} characters", nameof(name));
            
        if (trimmedName.Any(char.IsDigit))
            throw new ArgumentException("Publisher name cannot contain numbers", nameof(name));
            
        if (!char.IsUpper(trimmedName[0]))
            throw new ArgumentException("Publisher name must start with a capital letter", nameof(name));
    }

    public bool Equals(Publisher? other)
        => other is not null && Name == other.Name;

    public override bool Equals(object? obj)
        => Equals(obj as Publisher);

    public override int GetHashCode()
        => Name.GetHashCode();

    public override string ToString() => Name;

    public static bool operator ==(Publisher? left, Publisher? right)
        => EqualityComparer<Publisher>.Default.Equals(left, right);

    public static bool operator !=(Publisher? left, Publisher? right)
        => !(left == right);
}