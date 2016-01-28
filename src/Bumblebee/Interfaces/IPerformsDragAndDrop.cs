using OpenQA.Selenium;

namespace Bumblebee.Interfaces
{
	public interface IPerformsDragAndDrop
	{
		void DragAndDrop(IWebElement drag, IWebElement drop);
		void DragAndDrop(IWebElement drag, int offsetX, int offsetY);
	}
}
