using Server.Models;

namespace Server.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<T> WithUrls<T>(
        this IEnumerable<T> data,
        string baseUrl
    ) where T : IHasUrl
    {
        foreach (var i in data)
        {
            i.Url = $"{baseUrl}/{i.Id}";
            yield return i;
        }
    }
}
