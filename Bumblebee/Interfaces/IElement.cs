using Bumblebee.Setup;
using OpenQA.Selenium;

namespace Bumblebee.Interfaces
{
    public interface IElement : IDraggable
    {
        Session Session { get; }
    }
}
