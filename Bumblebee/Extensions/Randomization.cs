using System;
using System.Collections.Generic;
using System.Linq;

namespace Bumblebee.Extensions
{
	public static class Randomization
	{
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
		{
			var rng = new Random();

			return source.Shuffle(rng);
		}

		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}

			if (rng == null)
			{
				throw new ArgumentNullException("rng");
			}

			return source.ShuffleIterator(rng);
		}

		private static IEnumerable<T> ShuffleIterator<T>(this IEnumerable<T> source, Random rng)
		{
			var buffer = source.ToList();

			for (var i = 0; i < buffer.Count; i++)
			{
				var j = rng.Next(i, buffer.Count);
				yield return buffer[j];

				buffer[j] = buffer[i];
			}
		}

		public static T Random<T>(this IEnumerable<T> source)
		{
			var rng = new Random();

			return source.Random(rng);
		}

		public static T Random<T>(this IEnumerable<T> source, Random rng)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}

			if (rng == null)
			{
				throw new ArgumentNullException("rng");
			}

			return RandomIterator(source, rng);
		}

		private static T RandomIterator<T>(this IEnumerable<T> source, Random rng)
		{
			var buffer = source as IList<T> ?? source.ToList();
			return buffer[rng.Next(buffer.Count)];
		}
	}
}
