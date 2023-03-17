using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardTailzor.Data.Models.Extensions
{
    public static class EnumerableExtensions
    {
        public static ImmutableArray<T> EmptyIfNull<T>(this ImmutableArray<T>? elements)
        {
            return elements ?? ImmutableArray<T>.Empty;
        }

        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T>? elements)
        {
            return elements ?? Enumerable.Empty<T>();
        }

        public static IEnumerable<T> ExceptItem<T>(this IEnumerable<T>? elements, T? exceptItem)
        {
            if (elements == null)
            {
                return Enumerable.Empty<T>();
            }

            if (exceptItem == null)
            {
                return elements;
            }

            return elements.Except(new[] { exceptItem });
        }

        public static T MaxOfDefault<T>(this IEnumerable<T> items, T defaultValue = default(T)!)
        {
            if (items?.Any() != true)
            {
                return defaultValue;
            }

            return items.Max()!;
        }

        public static IEnumerable<T>? WithoutNull<T>(this IEnumerable<T>? elements)
        {
            if (elements == null)
            {
                return elements;
            }

            return elements.Where(x => x != null);
        }
    }
}