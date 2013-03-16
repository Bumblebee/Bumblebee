using System;
using Bumblebee.Interfaces;
using OpenQA.Selenium.Interactions;

namespace Bumblebee.Extensions
{
    public static class AdvancedSeleniumActions
    {
        public static TElement Hover<TElement>(this TElement element, int pauseSeconds = 0) where TElement : IElement
        {
            new Actions(element.Session.Driver).MoveToElement(element.Tag).Perform();

            return element.Pause(pauseSeconds);
        }

        public static TParent DragAndDrop<TParent>(this TParent parent, Func<TParent, IDraggable> getDraggable, Func<TParent, IHasBackingElement> getDropzone) where TParent : IBlock
        {
            PerformDragAndDrop(parent, getDraggable, getDropzone);

            return parent;
        }

        public static TCustomResult DragAndDrop<TParent, TCustomResult>(this TParent parent, Func<TParent, IDraggable> getDraggable, Func<TParent, IHasBackingElement> getDropzone) where TParent : IBlock where TCustomResult : IBlock
        {
            PerformDragAndDrop(parent, getDraggable, getDropzone);

            return parent.Session.CurrentBlock<TCustomResult>();
        }

        private static void PerformDragAndDrop<TParent>(TParent parent, Func<TParent, IDraggable> getDraggable, Func<TParent, IHasBackingElement> getDropzone) where TParent : IBlock
        {
            var draggable = getDraggable.Invoke(parent);
            var dropzone = getDropzone.Invoke(parent);

            draggable.GetDragAndDropPerformer().DragAndDrop(draggable.Tag, dropzone.Tag);
        }
    }
}