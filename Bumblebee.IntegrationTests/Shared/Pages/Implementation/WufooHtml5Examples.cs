using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages.Implementation
{
    public class WufooHtml5Examples : WebBlock
    {
        public WufooHtml5Examples(Session session)
            : base(session)
        {
        }

        public IDateField<WufooHtml5Examples> Date
        {
            get { return new DateField<WufooHtml5Examples>(this, By.CssSelector("input[type='date']")); }
        }
    }
}
