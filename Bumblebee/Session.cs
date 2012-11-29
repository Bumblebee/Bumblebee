using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Bumblebee
{
    public class Session
    {
        public IWebDriver Driver { get; private set; }

        public Session(IDriverEnvironment environment)
        {
            Driver = environment.CreateWebDriver();
        }

        public TBlock NavigateTo<TBlock>(string url) where TBlock : Block
        {
            Driver.Navigate().GoToUrl(url);
            return CurrentBlock<TBlock>();
        }

        public TBlock CurrentBlock<TBlock>(IWebElement dom = null) where TBlock : Block
        {
            var type = typeof(TBlock);
            IList<Type> constructorSignature = new List<Type> { typeof(Session) };
            IList<object> constructorArgs = new List<object> { this };

            if (typeof(SpecificBlock).IsAssignableFrom(typeof(TBlock)))
            {
                constructorSignature.Add(typeof(IWebElement));
                constructorArgs.Add(dom);
            }

            var constructor = type.GetConstructor(constructorSignature.ToArray());

            if (constructor == null)
            {
                throw new ArgumentException("The result type specified (" + type + ") is not a valid block. " +
                                            "It must have a constructor that takes only a session.");
            }

            return (TBlock) constructor.Invoke(constructorArgs.ToArray());
        }

        public void End()
        {
            Driver.Quit();
        }
    }
}
