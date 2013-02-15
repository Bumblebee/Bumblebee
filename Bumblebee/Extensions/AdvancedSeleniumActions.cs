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
    }
}