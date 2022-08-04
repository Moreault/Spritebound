namespace Spritebound.Web.Mapping;

/// <summary>
/// Filename and coordinates indicating where the sprite is located in a web context.
/// </summary>
public record WebSpriteLocation : SpriteLocation
{
    public float Zoom { get; init; }

    public WebSpriteLocation(string filename, Rectangle<int> coordinates, float zoom = 1.0f) : base(filename, coordinates)
    {
        Zoom = zoom;
    }

    public WebSpriteLocation(string filename, Vector2<int> position, Size<int> size, float zoom = 1.0f) : this(filename, new Rectangle<int>(position, size), zoom)
    {

    }

    public override string ToString() => $"{Filename} ({Coordinates}) x{Zoom}";
}