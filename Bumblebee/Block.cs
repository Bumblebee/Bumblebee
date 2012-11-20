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

        protected IWebElement Dom { get; set; }

        protected Block(Session session)
        {
            Session = session;
            Thread.Sleep(200);
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

        protected void VerifyElementPresent(By by)
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

        protected void VerifyElementAbsent(By by)
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

        protected TResult Result<TResult>() where TResult : Block
        {
            var type = typeof (TResult);
            var constructor = type.GetConstructor(new[] {typeof (Session)});

            if (constructor == null)
            {
                throw new ArgumentException("The result type specified (" + type + ") is not valid as a result. " +
                                            "It must have a constructor that takes only a session.");
            }

            return (TResult) constructor.Invoke(new object[] {Session});
        }
    }
}
