namespace ToolBX.Spritebound;

/// <summary>
/// A named point on a frame that something else is positioned by : the hand a carried box hangs from, the
/// crown a hat sits on, the muzzle a weapon's light comes out of.
/// <para>
/// Named because a frame usually has more than one of them and they are not interchangeable — the point a
/// box is held at is not the point a barrel ends at — and because the name is what lets a consumer ask for
/// the one it means without knowing how many others the artist has authored. Names are compared without
/// regard to case, as <see cref="Events.FrameEvent"/>'s are.
/// </para>
/// </summary>
public sealed record FramePin
{
    /// <summary>
    /// What this point is, in whatever vocabulary the game uses. Never null.
    /// </summary>
    public string Name
    {
        get;
        init => field = value ?? string.Empty;
    } = string.Empty;

    /// <summary>
    /// Where the point sits, relative to the frame.
    /// </summary>
    public Vector3<int> Position { get; init; }

    public bool Equals(FramePin? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase) && Position == other.Position;
    }

    public override int GetHashCode() => HashCode.Combine(StringComparer.InvariantCultureIgnoreCase.GetHashCode(Name), Position);

    public override string ToString() => string.IsNullOrWhiteSpace(Name) ? $"Unnamed pin at {Position}" : $"Pin {Name} at {Position}";
}
