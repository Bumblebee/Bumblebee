using System.Collections.Generic;
using OpenQA.Selenium;

namespace Bumblebee
{
    public abstract class Block
    {
        public Session Session { get; private set; }

        public IWebElement Dom { get; protected set; }

        protected Block(Session session)
        {
            Session = session;
        }

        protected IList<IWebElement> GetElements(By by)
        {
            return Dom.FindElements(by);
        }

        protected IWebElement GetElement(By by)
        {
            return Dom.GetElement(by);
        }
    }
}
