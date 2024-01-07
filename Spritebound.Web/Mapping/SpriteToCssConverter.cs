namespace ToolBX.Spritebound.Web.Mapping;

/// <summary>
/// Converts a single sprite or multiple layered sprites to its CSS equivalent.
/// </summary>
public interface ISpriteToCssConverter
{
    /// <summary>
    /// Returns the CSS equivalent of the sprite(s).
    /// </summary>
    string Convert(params WebSpriteLocation[] sprites);

    /// <summary>
    /// Returns the CSS equivalent of the sprites.
    /// </summary>
    string Convert(IEnumerable<WebSpriteLocation> sprites);
}

[AutoInject(ServiceLifetime.Singleton)]
public class SpriteToCssConverter : ISpriteToCssConverter
{
    public string Convert(params WebSpriteLocation[] sprites) => Convert(sprites as IEnumerable<WebSpriteLocation>);

    public string Convert(IEnumerable<WebSpriteLocation> sprites)
    {
        if (sprites == null) throw new ArgumentNullException(nameof(sprites));
        var spritesList = sprites as IReadOnlyList<WebSpriteLocation> ?? sprites.ToList();
        if (!spritesList.Any()) return string.Empty;

        var bgs = spritesList.Reverse().Select(x => $"url({x.Filename}) -{x.Position.X}px -{x.Position.Y}px no-repeat").ToList();
        return $"background: {string.Join(", ", bgs)}; width: {spritesList.First().Size.Width}px; height: {spritesList.First().Size.Height}px; zoom:{spritesList.First().Zoom}; image-rendering: pixelated;";
    }
}