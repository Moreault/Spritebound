namespace ToolBX.Spritebound.Events;

public sealed record FrameEvent
{
    public string Name { get; init; } = string.Empty;

    public Vector3<int> Origin { get; init; }

    public bool Equals(FrameEvent? other)
    {
        if (other == null) return false;
        if (ReferenceEquals(this, other)) return true;
        return string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase) && Origin == other.Origin;
    }

    public override int GetHashCode() => HashCode.Combine(Name, Origin);

    public override string ToString() => string.IsNullOrWhiteSpace(Name) ? $"Trigger unnamed event at {Origin}" : $"Trigger event {Name} at {Origin}";
}