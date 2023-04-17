using System.Collections.Generic;
using UnityEngine;

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
    public static class TransformExtensions
    {

        public static void ClearParent(this Transform transform)
        {
            transform.SetParent(null);
        }
    }
}