using System.Collections.Generic;

namespace Extensions
{
    public static class ReadOnlyExtensions 
    {
        public static T Random<T>(this IReadOnlyList<T> list)
        {
            int randomIndex = UnityEngine.Random.Range(0, list.Count);
            return list[randomIndex];
        }
    }
}