namespace ToolBX.Spritebound;

public record AnimatedSpritesheet : Spritesheet
{
    public IReadOnlyList<Animation> Animations { get; init; } = Array.Empty<Animation>();

    public virtual bool Equals(AnimatedSpritesheet? other) => base.Equals(other) && Animations.SequenceEqual(other.Animations);

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Animations);

    public override string ToString() => base.ToString();
}