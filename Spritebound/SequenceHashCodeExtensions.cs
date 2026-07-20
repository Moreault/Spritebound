namespace ToolBX.Spritebound;

internal static class SequenceHashCodeExtensions
{
    /// <summary>
    /// Returns an order-sensitive hash code over the sequence's elements, consistent with SequenceEqual-based equality.
    /// </summary>
    internal static int GetSequenceHashCode<T>(this IEnumerable<T>? source)
    {
        if (source is null) return 0;

        unchecked
        {
            var hash = 17;
            foreach (var item in source)
                hash = hash * 31 + (item?.GetHashCode() ?? 0);
            return hash;
        }
    }
}
