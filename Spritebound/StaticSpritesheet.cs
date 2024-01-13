namespace ToolBX.Spritebound;

public record StaticSpritesheet : Spritesheet
{
    public IReadOnlyList<Rectangle<int>> Coordinates { get; init; } = Array.Empty<Rectangle<int>>();

    public virtual bool Equals(StaticSpritesheet? other) => base.Equals(other) && Coordinates.SequenceEqualOrNull(other.Coordinates);

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Coordinates.GetValueHashCode(Depth.Shallow));

    public override string ToString() => base.ToString();
}