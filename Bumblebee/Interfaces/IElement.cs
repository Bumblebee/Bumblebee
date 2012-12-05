using OpenQA.Selenium;

namespace Bumblebee.Interfaces
{
    public interface IElement
    {
        IWebElement Dom { get; }
    }
}