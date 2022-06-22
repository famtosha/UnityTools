using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace UnityTools.Extentions
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> NotNull<T>(this IEnumerable<T> ts)
        {
            return ts.Where(x => x != null);
        }

        public static void ForEach<T>(this IEnumerable<T> ts, Action<T> action)
        {
            var enumarator = ts.GetEnumerator();
            while (enumarator.MoveNext())
            {
                action(enumarator.Current);
            }
        }

        public static T GetRandom<T>(this IEnumerable<T> enumerable)
        {
            var list = enumerable.ToList();
            return list.ToArray()[Random.Range(0, list.Count)];
        }

        public static T GetRandom<T>(this List<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }

        public static IEnumerable<T> OfType<T>(this IEnumerable<T> ts, Type type)
        {
            return ts.Where(x => x.GetType().IsAssignableFrom(type));
        }
    }
}