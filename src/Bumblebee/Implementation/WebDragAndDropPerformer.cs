using Bumblebee.Interfaces;

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Bumblebee.Implementation
{
	internal class WebDragAndDropPerformer : IPerformsDragAndDrop
	{
		public IWebDriver Driver { get; private set; }

		public WebDragAndDropPerformer(IWebDriver driver)
		{
			Driver = driver;
		}

		public void DragAndDrop(IWebElement drag, IWebElement drop)
		{
			new Actions(Driver).DragAndDrop(drag, drop).Build().Perform();
		}

		public void DragAndDrop(IWebElement drag, int xDrop, int yDrop)
		{
			new Actions(Driver).DragAndDropToOffset(drag, xDrop, yDrop).Build().Perform();
		}
	}
}
