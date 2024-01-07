namespace ToolBX.Spritebound;

public sealed record AnimatedSpritesheet : Spritesheet
{
    public IReadOnlyList<Animation> Animations { get; init; } = Array.Empty<Animation>();

    public bool Equals(AnimatedSpritesheet? other) => base.Equals(other) && Animations.SequenceEqualOrNull(other.Animations);

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Animations.GetValueHashCode());

    public override string ToString() => base.ToString();
}