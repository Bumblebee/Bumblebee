using Bumblebee.Interfaces;

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Bumblebee.Implementation
{
	internal class WebDragAndDropPerformer : IPerformsDragAndDrop
	{
		public IWebDriver Driver { get; }

		public WebDragAndDropPerformer(IWebDriver driver)
		{
			Driver = driver;
		}

		public void DragAndDrop(IWebElement drag, IWebElement drop)
		{
			new Actions(Driver).DragAndDrop(drag, drop).Build().Perform();
		}

		public void DragAndDrop(IWebElement drag, int offsetX, int offsetY)
		{
			new Actions(Driver).DragAndDropToOffset(drag, offsetX, offsetY).Build().Perform();
		}
	}
}
