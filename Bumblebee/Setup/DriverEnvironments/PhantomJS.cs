using System;
using OpenQA.Selenium.PhantomJS;

namespace Bumblebee.Setup.DriverEnvironments
{
    public class PhantomJS : SimpleDriverEnvironment<PhantomJSDriver>
    {
        public PhantomJS(TimeSpan timeToWait) 
            : base(timeToWait)
        { }

        public PhantomJS()
        { }
    }
}
