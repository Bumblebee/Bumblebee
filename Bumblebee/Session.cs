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

        public TBlock GoTo<TBlock>() where TBlock : Block
        {
            var type = typeof (TBlock);
            var method = type.GetMethod("GoTo");
            
            if (method == null)
            {
                throw new ArgumentException("Cannot go to block '" + type + "'. " +
                                            "Implement a static 'GoTo' method for the block.");
            }

            return (TBlock) method.Invoke(null, new object[] {this});
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
