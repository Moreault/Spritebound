using ToolBX.Spritebound.Events;

namespace ToolBX.Spritebound;

public record Frame
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
    public Vector3<int>? Pin { get; init; }

    /// <summary>
    /// Modifies the object's collider for this one frame.
    /// </summary>
    public Rectangle<int>? Collider { get; init; }
}