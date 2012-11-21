using System;
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

        public Session(IWebDriver driver)
        {
            Driver = driver;
        }

        public TBlock NavigateTo<TBlock>(string url) where TBlock : Block
        {
            Driver.Navigate().GoToUrl(url);
            return CurrentBlock<TBlock>();
        }

        public TBlock CurrentBlock<TBlock>() where TBlock : Block
        {
            var type = typeof(TBlock);
            var constructor = type.GetConstructor(new[] { typeof(Session) });

            if (constructor == null)
            {
                throw new ArgumentException("The result type specified (" + type + ") is not a valid block. " +
                                            "It must have a constructor that takes only a session.");
            }

            return (TBlock)constructor.Invoke(new object[] { this });
        }

        public void End()
        {
            Driver.Quit();
        }
    }
}
