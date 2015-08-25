using System.Collections.Generic;
using System.Linq;

using Bumblebee.Interfaces;

namespace Bumblebee.Extensions
{
	public static class Filtering
	{
		public static IEnumerable<TResult> WithText<TResult>(this IEnumerable<TResult> haveText, string text) where TResult : IHasText
		{
			return haveText.Where(hasText => hasText.Text.Trim() == text.Trim());
		}

		public static IEnumerable<TResult> ContainingText<TResult>(this IEnumerable<TResult> haveText, string text) where TResult : IHasText
		{
			return haveText.Where(hasText => hasText.Text.Contains(text.Trim()));
		}

		public static IEnumerable<TSelectable> Unselected<TSelectable>(this IEnumerable<TSelectable> options) where TSelectable : ISelectable
		{
			return options.Where(option => option.Selected == false);
		}

		public static IEnumerable<TSelectable> Selected<TSelectable>(this IEnumerable<TSelectable> options) where TSelectable : ISelectable
		{
			return options.Where(option => option.Selected);
		}
	}
}
