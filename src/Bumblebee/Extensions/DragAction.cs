using System;

using Bumblebee.Interfaces;

namespace Bumblebee.Extensions
{
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
		/// <typeparam name="TCustomResult">The type of the custom result.</typeparam>
		/// <param name="getDropzone">The get dropzone.</param>
		/// <returns></returns>
		public TCustomResult AndDrop<TCustomResult>(Func<TParent, IHasBackingElement> getDropzone) where TCustomResult : IBlock
		{
			PerformDragAndDrop(getDropzone);

			return Parent.Session.CurrentBlock<TCustomResult>();
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
		/// <typeparam name="TCustomResult">The type of the custom result.</typeparam>
		/// <param name="xOffset">The x offset.</param>
		/// <param name="yOffset">The y offset.</param>
		/// <returns></returns>
		public TCustomResult AndDrop<TCustomResult>(int xOffset, int yOffset) where TCustomResult : IBlock
		{
			PerformDragAndDrop(xOffset, yOffset);

			return Parent.Session.CurrentBlock<TCustomResult>();
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