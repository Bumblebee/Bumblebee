using OpenQA.Selenium;

namespace Bumblebee.Interfaces
{
    public interface IElement
    {
        IWebElement Tag { get; }
    }
}