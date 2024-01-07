namespace ToolBX.Spritebound.Mapping;

/// <summary>
/// Filename and coordinates indicating where the sprite is located.
/// </summary>
public record SpriteLocation
{
    //TODO 3.0.0 : required, throw on IsNullOrWhiteSpace
    public string Filename { get; init; } = string.Empty;

    public Rectangle<int> Coordinates { get; init; }

    public Vector2<int> Position => Coordinates.Position;

    public Size<int> Size => Coordinates.Size;

    public SpriteLocation()
    {

    }

    public SpriteLocation(string name) : this(name, new Rectangle<int>())
    {

    }

    public SpriteLocation(string name, int width, int height) : this(name, new Rectangle<int>(0, 0, width, height))
    {

    }

    public SpriteLocation(string name, int x, int y, int width, int height) : this(name, new Rectangle<int>(x, y, width, height))
    {

    }

    public SpriteLocation(string name, Size<int> size) : this(name, new Rectangle<int>(0, 0, size))
    {

    }

    public SpriteLocation(string name, Vector2<int> position, Size<int> size) : this(name, new Rectangle<int>(position, size))
    {

    }

    public SpriteLocation(string name, Rectangle<int> coordinates)
    {
        Filename = name;
        Coordinates = coordinates;
    }

    //TODO 3.0.0 : Remove condition since Filename is required and can never be null or empty
    public override string ToString() => string.IsNullOrWhiteSpace(Filename) ? "Invalid sprite location" : $"Sprite '{Path.GetFileName(Filename)}' at {Coordinates}";
}