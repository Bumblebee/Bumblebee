using System;
using Bumblebee.Interfaces;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Bumblebee.Extensions
{
    public static class AdvancedSeleniumActions
    {
        public static TElement Hover<TElement>(this TElement element, int miliseconds = 0) where TElement : IElement
        {
            new Actions(element.Session.Driver).MoveToElement(element.Tag).Perform();

            return element.Pause(miliseconds);
        }

        public static DragAction<TParent> Drag<TParent>(this TParent parent, Func<TParent, IDraggable> getDraggable) where TParent : IBlock
        {
            return new DragAction<TParent>(parent, getDraggable);
        }

        public static TParent WaitUntil<TParent>(this TParent parent, Predicate<TParent> condition, int miliseconds = 10000) where TParent : IBlock
        {
            var wait = new DefaultWait<TParent>(parent) {Timeout = new TimeSpan(miliseconds)};
            wait.Until(condition.Invoke);
            return parent;
        }
    }

    public class DragAction<TParent> where TParent : IBlock
    {
        private TParent Parent { get; set; }
        private IDraggable Draggable { get; set; }

        public DragAction(TParent parent, Func<TParent, IDraggable> getDraggable)
        {
            Parent = parent;
            Draggable = getDraggable(parent);
        }

        public TParent AndDrop(Func<TParent, IHasBackingElement> getDropzone)
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
            var dropzone = getDropzone(Parent);

            Parent.GetDragAndDropPerformer().DragAndDrop(Draggable.Tag, dropzone.Tag);
        }

        private void PerformDragAndDrop(int x, int y)
        {
            Parent.GetDragAndDropPerformer().DragAndDrop(Draggable.Tag, x, y);
        }
    }
}