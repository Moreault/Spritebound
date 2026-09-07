namespace ToolBX.Spritebound;

public sealed record Frame
{
    /// <summary>
    /// This frame's coordinates on the spritesheet.
    /// </summary>
    public Rectangle<int> Coordinates { get; init; }

    /// <summary>
    /// Corrects the frame's position. Use only if necessary.
    /// </summary>
    public Vector3<int> Offset { get; init; }

    /// <summary>
    /// Extra time spent on this frame during the animation. This ignores the parent animation's FramesPerSecond property.
    /// </summary>
    public float Delay { get; init; }

    /// <summary>
    /// Event that is triggered on this exact frame.
    /// </summary>
    public FrameEvent? Event { get; init; }

    /// <summary>
    /// Position of an attachment that follows the sprite's animation (ex : a hat or a sword) so that the game knows where to place it.
    /// </summary>
    [Obsolete($"Use {nameof(Pins)} instead : one unnamed point can only ever position one thing, and a frame that has both a hand and a muzzle has no way to say so. This property is still read and written as authored, so existing data keeps working until it is converted.")]
    public Vector3<int>? Pin { get; init; }

    /// <summary>
    /// Points on this frame that other things are positioned by, each under its own name — see <see cref="FramePin"/>.
    /// <para>
    /// Never null : a frame with nothing pinned to it hands back an empty list, so a caller can iterate it
    /// without a guard.
    /// </para>
    /// </summary>
    public IReadOnlyList<FramePin> Pins
    {
        get => _pins;
        init => _pins = value ?? Array.Empty<FramePin>();
    }
    private readonly IReadOnlyList<FramePin> _pins = Array.Empty<FramePin>();

    /// <summary>
    /// Modifies the object's collider for this one frame.
    /// </summary>
    public Rectangle<int>? Collider { get; init; }

    /// <summary>
    /// Declared rather than left to the compiler because of <see cref="_hashCode"/> : the generated copy
    /// constructor copies every field, private ones included, so a <c>with</c> expression would hand the
    /// clone the original's cached hash and then change the members it was computed from. Nothing would
    /// throw; the clone would simply hash as something it no longer is.
    /// </summary>
    private Frame(Frame original)
    {
        Coordinates = original.Coordinates;
        Offset = original.Offset;
        Delay = original.Delay;
        Event = original.Event;
#pragma warning disable CS0618 // Copying a frame has to carry the obsolete member for as long as it exists.
        Pin = original.Pin;
#pragma warning restore CS0618
        _pins = original._pins;
        Collider = original.Collider;
    }

    /// <summary>
    /// The pin named <paramref name="name"/>, or null if this frame hasn't got one. Compared without
    /// regard to case, as <see cref="FramePin.Equals(FramePin)"/> is.
    /// <para>
    /// A linear walk on purpose : a frame carries a handful of pins at most, which a dictionary would cost
    /// more to build than it could ever save on lookup.
    /// </para>
    /// </summary>
    public Vector3<int>? GetPin(string name)
    {
        for (var i = 0; i < _pins.Count; i++)
            if (string.Equals(_pins[i].Name, name, StringComparison.InvariantCultureIgnoreCase))
                return _pins[i].Position;
        return null;
    }

    public bool Equals(Frame? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
#pragma warning disable CS0618 // Two frames still differ by their obsolete pin for as long as it is authored.
        var samePin = Pin == other.Pin;
#pragma warning restore CS0618
        return Coordinates == other.Coordinates &&
               Offset == other.Offset &&
               Delay.Equals(other.Delay) &&
               Equals(Event, other.Event) &&
               samePin &&
               Pins.SequenceEqual(other.Pins) &&
               Collider == other.Collider;
    }

    public override int GetHashCode() => _hashCode ??= ComputeHashCode();

    private int? _hashCode;

    private int ComputeHashCode()
    {
#pragma warning disable CS0618
        var pin = Pin;
#pragma warning restore CS0618
        return HashCode.Combine(Coordinates, Offset, Delay, Event, pin, Pins.GetSequenceHashCode(), Collider);
    }
}
