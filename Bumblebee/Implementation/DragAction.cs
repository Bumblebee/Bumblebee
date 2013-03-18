using System;
using Bumblebee.Interfaces;

namespace Bumblebee.Implementation
{
    public class DragAction<TParent> where TParent : IBlock
    {
        private TParent Parent { get; set; }
        private Func<TParent, IDraggable> GetDraggable { get; set; }

        public DragAction(TParent parent, Func<TParent, IDraggable> getDraggable)
        {
            Parent = parent;
            GetDraggable = getDraggable;
        }

        public TParent AndDrop(Func<TParent, IBlock> getDropzone)
        {
            PerformDragAndDrop(getDropzone);

            return Parent.Session.CurrentBlock<TParent>();
        }

        public TCustomResult AndDrop<TCustomResult>(Func<TParent, IHasBackingElement> getDropzone) where TCustomResult : IBlock
        {
            PerformDragAndDrop(getDropzone);

            return Parent.Session.CurrentBlock<TCustomResult>();
        }

        private void PerformDragAndDrop(Func<TParent, IHasBackingElement> getDropzone)
        {
            var draggable = GetDraggable.Invoke(Parent);
            var dropzone = getDropzone.Invoke(Parent);

            draggable.GetDragAndDropPerformer().DragAndDrop(draggable.Tag, dropzone.Tag);
        }
    }
}
