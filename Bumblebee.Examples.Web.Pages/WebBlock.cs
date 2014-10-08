using System;
using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Bumblebee.Examples.Web.Pages
{
    public class WebBlock : Block
    {
        protected WebDriverWait Wait { get; private set; }

        public WebBlock(Session session) : base(session)
        {
            // Wait for the DOM to start changing so we can START waiting for the new element
            this.Pause(200);
            Wait = new WebDriverWait(Session.Driver, new TimeSpan(3000));
            Tag = Wait.Until(driver => driver.GetElement(By.TagName("body")));
        }
    }
}
