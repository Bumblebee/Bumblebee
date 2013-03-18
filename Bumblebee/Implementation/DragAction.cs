using System;
using Bumblebee.Interfaces;

namespace Bumblebee.Implementation
{
    public class DragAction<TParent> where TParent : IBlock
    {
        private TParent Parent { get; set; }
        private IDraggable Draggable { get; set; }

        public DragAction(TParent parent, Func<TParent, IDraggable> getDraggable)
        {
            Parent = parent;
            Draggable = getDraggable.Invoke(parent);
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

        public TParent AndDrop(int x, int y)
        {
            PerformDragAndDrop(x, y);

            return Parent.Session.CurrentBlock<TParent>();
        }

        public TCustomResult AndDrop<TCustomResult>(int x, int y) where TCustomResult : IBlock
        {
            PerformDragAndDrop(x, y);

            return Parent.Session.CurrentBlock<TCustomResult>();
        }

        private void PerformDragAndDrop(Func<TParent, IHasBackingElement> getDropzone)
        {
            var dropzone = getDropzone.Invoke(Parent);

            Draggable.GetDragAndDropPerformer().DragAndDrop(Draggable.Tag, dropzone.Tag);
        }

        private void PerformDragAndDrop(int x, int y)
        {
            Draggable.GetDragAndDropPerformer().DragAndDrop(Draggable.Tag, x, y);
        }
    }
}
