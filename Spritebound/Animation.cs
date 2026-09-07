namespace ToolBX.Spritebound;

public sealed record Animation : IAutoIncrementedId<int>
{
    public int Id { get; init; }

    /// <summary>
    /// Short description or name to describe what the animation is. This is for your own convenience and shouldn't be displayed or used in-game.
    /// </summary>
    public string Description { get; init; } = string.Empty;

    public IReadOnlyList<Frame> Frames
    {
        get => _frames;
        init => _frames = value ?? Array.Empty<Frame>();
    }
    private readonly IReadOnlyList<Frame> _frames = [];

    /// <summary>
    /// Speed of the animation. This is the amount of frames that are displayed in a second.
    /// </summary>
    public float FramesPerSecond
    {
        get => _framesPerSecond;
        init => _framesPerSecond = Math.Clamp(value, 0, int.MaxValue);
    }
    private readonly float _framesPerSecond;

    public bool IsLooped { get; init; }

    /// <summary>
    /// Frame at which the animation is restarted when it is looped. This only applies to animations that have an 'introduction phase'. Otherwise, leave it at zero.
    /// </summary>
    public int LoopRestartIndex
    {
        get => _loopRestartIndex;
        init => _loopRestartIndex = Math.Clamp(value, 0, int.MaxValue);
    }
    private readonly int _loopRestartIndex;

    /// <summary>
    /// Total duration of the animation based on speed and number of frames. In the case of looped animations, this represents a single cycle of animation.
    /// </summary>
    public float Duration => FramesPerSecond == 0 ? 0 : Frames.Count / FramesPerSecond + Frames.Sum(x => x.Delay);

    /// <summary>
    /// Corrects the animation's position. Use only if necessary.
    /// </summary>
    public Vector3<int> Offset { get; init; }

    /// <summary>
    /// Declared rather than left to the compiler for the same reason <see cref="Frame"/> declares one : the
    /// generated copy constructor copies private fields too, so a <c>with</c> expression would carry the
    /// original's cached hash onto a clone whose frames are no longer the ones it was computed from.
    /// </summary>
    private Animation(Animation original)
    {
        Id = original.Id;
        Description = original.Description;
        _frames = original._frames;
        _framesPerSecond = original._framesPerSecond;
        IsLooped = original.IsLooped;
        _loopRestartIndex = original._loopRestartIndex;
        Offset = original.Offset;
    }

    public override string ToString() => $"Animation {Id}";

    public bool Equals(Animation? other)
    {
        if (other == null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id &&
               Frames.SequenceEqual(other.Frames) &&
               FramesPerSecond.Equals(other.FramesPerSecond) &&
               IsLooped == other.IsLooped &&
               LoopRestartIndex == other.LoopRestartIndex &&
               Offset == other.Offset;
    }

    /// <summary>
    /// Cached : hashing an animation walks every frame, and a frame hashes its own pins, so this is O(the
    /// whole animation) to compute and constant to keep. An animation is immutable once built — a
    /// <c>with</c> goes through the copy constructor above, which drops the cache.
    /// </summary>
    public override int GetHashCode() => _hashCode ??= HashCode.Combine(Id, Description, Frames.GetSequenceHashCode(), FramesPerSecond, IsLooped, LoopRestartIndex, Offset);

    private int? _hashCode;
}