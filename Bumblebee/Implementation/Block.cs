using System;
using System.Collections.Generic;
using Bumblebee.Extensions;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
    public abstract class Block : IBlock
    {
        public Session Session { get; private set; }

        public IWebElement Tag { get; protected set; }

        protected Block(Session session)
        {
            Session = session;

            if (Session.Monkey != null)
            {
                Session.Monkey.Invoke(this);
            }
        }

        public IList<IWebElement> GetElements(By by)
        {
            if (Tag == null)
                throw new NullReferenceException("You can't call GetElements on a block without first initializing Tag.");

            return Tag.FindElements(by);
        }

        public IWebElement GetElement(By by)
        {
            if (Tag == null)
                throw new NullReferenceException("You can't call GetElement on a block without first initializing Tag.");

            return Tag.GetElement(by);
        }

        public virtual IPerformsDragAndDrop GetDragAndDropPerformer()
        {
            return new WebDragAndDropPerformer(Session.Driver);
        }

        public virtual void VerifyMonkeyState()
        {
        }
    }
}
