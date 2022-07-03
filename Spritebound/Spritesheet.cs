namespace ToolBX.Spritebound;

public abstract record Spritesheet : IAutoIncrementedId<int>
{
    public int Id { get; init; }

    public string Filename { get; init; } = string.Empty;

    public virtual bool Equals(Spritesheet? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return Id == other.Id && Filename == other.Filename;
    }

    public override int GetHashCode() => HashCode.Combine(Id, Filename);

    public override string ToString()
    {
        return string.IsNullOrWhiteSpace(Filename)
            ? $"Spritesheet {Id}"
            : $"Spritesheet {Id} ({Path.GetFileName(Filename)})";
    }
}