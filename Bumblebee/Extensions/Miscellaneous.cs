using System;
using System.Collections.Generic;

namespace Bumblebee.Extensions
{
	public static class Miscellaneous
	{
		public static void Each<T>(this IEnumerable<T> enumerable, Action<T> function)
		{
			foreach (var member in enumerable)
			{
				function(member);
			}
		}

		public static InlineControlFlow<T> Do<T>(this T subject, Action<T> action)
		{
			return new InlineControlFlow<T>(action, subject);
		}
	}

	public class InlineControlFlow<T>
	{
		public Action<T> Action { get; protected set; }
		public T Subject { get; protected set; }

		public InlineControlFlow(Action<T> action, T subject)
		{
			Action = action;
			Subject = subject;
		}

		public T While(Predicate<T> predicate)
		{
			while (predicate(Subject)) Action(Subject);

			return Subject;
		}

		public T Until(Predicate<T> predicate)
		{
			while (!predicate(Subject)) Action(Subject);

			return Subject;
		}

		public T For(Action<T> init, Predicate<T> predicate, Action<T> iterator)
		{
			for (init(Subject); predicate(Subject); iterator(Subject)) Action(Subject);

			return Subject;
		}

		public T Times(int times)
		{
			while (times-- > 0) Action(Subject);

			return Subject;
		}

		public T If(Predicate<T> predicate)
		{
			if (predicate(Subject)) Action(Subject);

			return Subject;
		}

		public T Unless(Predicate<T> predicate)
		{
			if (!predicate(Subject)) Action(Subject);

			return Subject;
		}
	}
}
