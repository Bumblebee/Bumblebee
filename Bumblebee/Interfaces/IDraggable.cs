using OpenQA.Selenium;

namespace Bumblebee.Interfaces
{
    public interface IDraggable : IHasBackingElement
    {
        IPerformsDragAndDrop GetDragAndDropPerformer();
    }
}
