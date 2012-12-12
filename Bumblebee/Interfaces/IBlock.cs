using OpenQA.Selenium;

namespace Bumblebee.Interfaces
{
    public interface IBlock
    {
        Session Session { get; }
        IWebElement Tag { get; }
    }
}