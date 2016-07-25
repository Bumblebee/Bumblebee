using System;

using Bumblebee.Interfaces;

using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Bumblebee.Extensions
{
	public static class AdvancedSeleniumActions
	{
		/// <summary>
		/// Performs the hover action on the specified element.
		/// </summary>
		/// <typeparam name="TElement">The type of the element.</typeparam>
		/// <param name="element">The element.</param>
		/// <param name="milliseconds">The time to wait, in milliseconds.</param>
		/// <returns></returns>
		public static TElement Hover<TElement>(this TElement element, int milliseconds = 0) where TElement : IElement
		{
			new Actions(element.Session.Driver).MoveToElement(element.Tag).Perform();

			return element.Pause(milliseconds);
		}

		/// <summary>
		/// Drags an element from the specified parent block.
		/// </summary>
		/// <typeparam name="TParent">The type of the parent block.</typeparam>
		/// <param name="parent">The parent block.</param>
		/// <param name="getDraggable">The lambda that gets the element to be dragged.</param>
		/// <returns></returns>
		public static DragAction<TParent> Drag<TParent>(this TParent parent, Func<TParent, IDraggable> getDraggable) where TParent : IBlock
		{
			return new DragAction<TParent>(parent, getDraggable);
		}

		/// <summary>
		/// Waits until <paramref name="condition" /> true, or until the timeout has expired, whichever comes first.
		/// </summary>
		/// <typeparam name="TParent">The type of the parent block.</typeparam>
		/// <param name="parent">The parent block.</param>
		/// <param name="condition">The condition to wait for.</param>
		/// <param name="milliseconds">The time to wait, in milliseconds.</param>
		/// <returns></returns>
		public static TParent WaitUntil<TParent>(this TParent parent, Predicate<TParent> condition, int milliseconds = 10000) where TParent : IBlock
		{
			var wait = new DefaultWait<TParent>(parent)
			{
				Timeout = TimeSpan.FromMilliseconds(milliseconds)
			};

			wait.Until(condition.Invoke);

			return parent;
		}
	}
}
