using System;

using Bumblebee.Interfaces;

namespace Bumblebee.Extensions
{
	/// <summary>
	/// Represents the drag action.
	/// </summary>
	/// <typeparam name="TParent">The type of the parent block.</typeparam>
	public class DragAction<TParent>
		where TParent : IBlock
	{
		private readonly TParent _parent;
		private readonly IDraggable _draggable;

		/// <summary>
		/// Initializes a new instance of the <see cref="DragAction{TParent}" /> class.
		/// </summary>
		/// <param name="parent">The parent.</param>
		/// <param name="getDraggable">The lambda that gets the element to be dragged.</param>
		public DragAction(TParent parent, Func<TParent, IDraggable> getDraggable)
		{
			_parent = parent;
			_draggable = getDraggable(parent);
		}

		/// <summary>
		/// Fluent syntax for indicating the drop element.
		/// </summary>
		/// <param name="getDropzone">The lambda that gets the element that is the drop target.</param>
		/// <returns></returns>
		public TParent AndDrop(Func<TParent, IHasBackingElement> getDropzone)
		{
			PerformDragAndDrop(getDropzone);

			return _parent;
		}

		/// <summary>
		/// Fluent syntax for indicating the drop element.
		/// </summary>
		/// <typeparam name="TCustomResult">The type of the custom result.</typeparam>
		/// <param name="getDropzone">The lambda that gets the element that is the drop target.</param>
		/// <returns></returns>
		public TCustomResult AndDrop<TCustomResult>(Func<TParent, IHasBackingElement> getDropzone) where TCustomResult : IBlock
		{
			PerformDragAndDrop(getDropzone);

			return _parent.FindRelated<TCustomResult>();
		}

		/// <summary>
		/// Fluent syntax for indicating the drop element.
		/// </summary>
		/// <param name="offsetX">The x offset.</param>
		/// <param name="offsetY">The y offset.</param>
		/// <returns></returns>
		public TParent AndDrop(int offsetX, int offsetY)
		{
			PerformDragAndDrop(offsetX, offsetY);

			return _parent;
		}

		/// <summary>
		/// Fluent syntax for indicating the drop element.
		/// </summary>
		/// <typeparam name="TCustomResult">The type of the custom result.</typeparam>
		/// <param name="offsetX">The x offset.</param>
		/// <param name="offsetY">The y offset.</param>
		/// <returns></returns>
		public TCustomResult AndDrop<TCustomResult>(int offsetX, int offsetY) where TCustomResult : IBlock
		{
			PerformDragAndDrop(offsetX, offsetY);

			return _parent.FindRelated<TCustomResult>();
		}

		private void PerformDragAndDrop(Func<TParent, IHasBackingElement> getDropzone)
		{
			var dropzone = getDropzone(_parent);

			_parent.GetDragAndDropPerformer().DragAndDrop(_draggable.Tag, dropzone.Tag);
		}

		private void PerformDragAndDrop(int offsetX, int offsetY)
		{
			_parent.GetDragAndDropPerformer().DragAndDrop(_draggable.Tag, offsetX, offsetY);
		}
	}
}
