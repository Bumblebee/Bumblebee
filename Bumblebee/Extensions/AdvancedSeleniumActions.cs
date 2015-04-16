using System;

using Bumblebee.Interfaces;

using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Bumblebee.Extensions
{
	public static class AdvancedSeleniumActions
	{
		/// <summary>
		/// Hovers the specified element.
		/// </summary>
		/// <typeparam name="TElement">The type of the element.</typeparam>
		/// <param name="element">The element.</param>
		/// <param name="miliseconds">The miliseconds.</param>
		/// <returns></returns>
		public static TElement Hover<TElement>(this TElement element, int miliseconds = 0) where TElement : IElement
		{
			new Actions(element.Session.Driver).MoveToElement(element.Tag).Perform();

			return element.Pause(miliseconds);
		}

		/// <summary>
		/// Drags an element from the specified parent block.
		/// </summary>
		/// <typeparam name="TParent">The type of the parent block.</typeparam>
		/// <param name="parent">The parent block.</param>
		/// <param name="getDraggable">The get draggable.</param>
		/// <returns></returns>
		public static DragAction<TParent> Drag<TParent>(this TParent parent, Func<TParent, IDraggable> getDraggable) where TParent : IBlock
		{
			return new DragAction<TParent>(parent, getDraggable);
		}

		/// <summary>
		/// Waits the until.
		/// </summary>
		/// <typeparam name="TParent">The type of the parent block.</typeparam>
		/// <param name="parent">The parent block.</param>
		/// <param name="condition">The condition.</param>
		/// <param name="miliseconds">The miliseconds.</param>
		/// <returns></returns>
		public static TParent WaitUntil<TParent>(this TParent parent, Predicate<TParent> condition, int miliseconds = 10000) where TParent : IBlock
		{
			var wait = new DefaultWait<TParent>(parent)
			{
				Timeout = TimeSpan.FromMilliseconds(miliseconds)
			};

			wait.Until(condition.Invoke);

			return parent;
		}
	}

	/// <summary>
	/// Represents the drag action.
	/// </summary>
	/// <typeparam name="TParent">The type of the parent block.</typeparam>
	public class DragAction<TParent> where TParent : IBlock
	{
		private TParent Parent { get; set; }
		private IDraggable Draggable { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="DragAction{TParent}"/> class.
		/// </summary>
		/// <param name="parent">The parent.</param>
		/// <param name="getDraggable">The get draggable.</param>
		public DragAction(TParent parent, Func<TParent, IDraggable> getDraggable)
		{
			Parent = parent;
			Draggable = getDraggable(parent);
		}

		/// <summary>
		/// Fluent syntax for indicating the drop element.
		/// </summary>
		/// <param name="getDropzone">The get dropzone.</param>
		/// <returns></returns>
		public TParent AndDrop(Func<TParent, IHasBackingElement> getDropzone)
		{
			PerformDragAndDrop(getDropzone);

			return Parent.Session.CurrentBlock<TParent>();
		}

		/// <summary>
		/// Fluent syntax for indicating the drop element.
		/// </summary>
		/// <typeparam name="TResult">The type of the custom result.</typeparam>
		/// <param name="getDropzone">The get dropzone.</param>
		/// <returns></returns>
		public TResult AndDrop<TResult>(Func<TParent, IHasBackingElement> getDropzone) where TResult : IBlock
		{
			PerformDragAndDrop(getDropzone);

			return Parent.Session.CurrentBlock<TResult>();
		}

		/// <summary>
		/// Fluent syntax for indicating the drop element.
		/// </summary>
		/// <param name="xOffset">The x offset.</param>
		/// <param name="yOffset">The y offset.</param>
		/// <returns></returns>
		public TParent AndDrop(int xOffset, int yOffset)
		{
			PerformDragAndDrop(xOffset, yOffset);

			return Parent.Session.CurrentBlock<TParent>();
		}

		/// <summary>
		/// Fluent syntax for indicating the drop element.
		/// </summary>
		/// <typeparam name="TResult">The type of the custom result.</typeparam>
		/// <param name="xOffset">The x offset.</param>
		/// <param name="yOffset">The y offset.</param>
		/// <returns></returns>
		public TResult AndDrop<TResult>(int xOffset, int yOffset) where TResult : IBlock
		{
			PerformDragAndDrop(xOffset, yOffset);

			return Parent.Session.CurrentBlock<TResult>();
		}

		private void PerformDragAndDrop(Func<TParent, IHasBackingElement> getDropzone)
		{
			var dropzone = getDropzone(Parent);

			Parent.GetDragAndDropPerformer().DragAndDrop(Draggable.Tag, dropzone.Tag);
		}

		private void PerformDragAndDrop(int xOffset, int yOffset)
		{
			Parent.GetDragAndDropPerformer().DragAndDrop(Draggable.Tag, xOffset, yOffset);
		}
	}
}
