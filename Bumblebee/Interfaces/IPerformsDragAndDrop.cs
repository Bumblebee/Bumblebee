using OpenQA.Selenium;

namespace Bumblebee.Interfaces
{
    public interface IPerformsDragAndDrop
    {
        void DragAndDrop(IWebElement drag, IWebElement drop);
        void DragAndDrop(IWebElement drag, int xDrop, int yDrop);
        void DragAndDrop(int xDrag, int yDrag, int xDrop, int yDrop);
    }
}
