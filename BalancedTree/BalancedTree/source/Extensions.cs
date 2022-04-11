using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedTree
{
	public static class Extensions
	{
		public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool>? predicate = null)
		{
			if (predicate == null)
			{
				var enumerator = source.GetEnumerator();
				return enumerator.MoveNext();
			}
			else
			{
				foreach (var element in source)
				{
					if (predicate(element))
					{
						return true;
					}
				}
				return false;
			}
		}

		public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			foreach (var element in source)
			{
				if (!predicate(element))
				{
					return false;
				}
			}
			return true;
		}

		public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate = null)
		{
			int count = 0;
			IEnumerator<TSource> enumerator = source.GetEnumerator();
			if (predicate == null)
			{
				while (enumerator.MoveNext())
				{
					if (count == int.MaxValue) throw new OverflowException();
					count++;
				}
			}
			else
			{
				while (enumerator.MoveNext())
				{
					if (predicate(enumerator.Current))
					{
						if (count == int.MaxValue) throw new OverflowException();
						count++;
					}
				}
			}
			return count;
		}

		public static TSource ElementAt<TSource>(this IEnumerable<TSource> source, int index)
		{
			var enumerator = source.GetEnumerator();
			if (index < 0) throw new ArgumentOutOfRangeException();
			for (int i = 0; i < index; i++)
			{
				if (!enumerator.MoveNext())
				{
					throw new ArgumentOutOfRangeException();
				}
			}
			return enumerator.Current;
		}

		public static TSource ElementAtOrDefault<TSource>(this IEnumerable<TSource> source, int index)
		{
			var enumerator = source.GetEnumerator();
			if (index < 0) return default;
			for (int i = 0; i < index; i++)
			{
				if (!enumerator.MoveNext())
				{
					return default;
				}
			}
			return enumerator.Current;
		}

		public static TSource First<TSource>(this IEnumerable<TSource> source)
		{
			if (source.Count() == 0) throw new InvalidOperationException();
			var enumerator = source.GetEnumerator();
			enumerator.MoveNext();
			return enumerator.Current;
		}

		public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
		{
			if (source.Count() == 0) return default;
			var enumerator = source.GetEnumerator();
			enumerator.MoveNext();
			return enumerator.Current;
		}

		public static TSource Last<TSource>(this IEnumerable<TSource> source)
		{
			var enumerator = source.GetEnumerator();
			TSource previous = default;
		
				while (enumerator.MoveNext())
				{
					previous = enumerator.Current;
				}
				return previous;
		}

		public static TSource Min<TSource>(this IEnumerable<TSource> source) where TSource : IComparable<TSource>
		{
			var enumerator = source.GetEnumerator();
			enumerator.MoveNext();
			TSource min = enumerator.Current;
			while (enumerator.MoveNext())
			{
				if (min.CompareTo(enumerator.Current) > 0) min = enumerator.Current;
			}
			return min;
		}

		public static TSource Max<TSource>(this IEnumerable<TSource> source) where TSource : IComparable<TSource>
		{
			var enumerator = source.GetEnumerator();
			enumerator.MoveNext();
			TSource max = enumerator.Current;
			while (enumerator.MoveNext())
			{
				if (max.CompareTo(enumerator.Current) < 0) max = enumerator.Current;
			}
			return max;
		}
	}
}