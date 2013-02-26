using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace Bumblebee.Interfaces
{
    public interface IElement
    {
        Session Session { get; }
        IWebElement Tag { get; }
    }
}
