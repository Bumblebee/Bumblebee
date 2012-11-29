using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ionic.Zip;
using OpenQA.Selenium;

namespace Bumblebee
{
    public abstract class Block
    {
        public Session Session { get; private set; }

        protected internal IWebElement Dom { get; protected set; }

        protected Block(Session session)
        {
            Session = session;
        }

        protected internal IList<IWebElement> GetElements(By by)
        {
            return Dom.FindElements(by);
        }

        protected internal IWebElement GetElement(By by)
        {
            try
            {
                return Dom.FindElements(by).First();
            } 
            catch (InvalidOperationException)
            {
                throw new NoSuchElementException("Tried to get element with selector " + by);
            }
        }

        protected internal void VerifyElementPresent(By by)
        {
            try
            {
                GetElement(by);
            }
            catch (NoSuchElementException)
            {
                throw new BadStateException("Couldn't verify presence of element " + by);
            }
        }

        protected internal void VerifyElementAbsent(By by)
        {
            try
            {
                GetElement(by);
            }
            catch (NoSuchElementException)
            {
                return;
            }
            throw new BadStateException("Couldn't verify absence of element " + by);
        }

        
    }
}
