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
    public class HtmlCodeTutorialSelectMultiplePage : WebBlock
    {
        public HtmlCodeTutorialSelectMultiplePage(Session session)
            : base(session)
        {
        }

        public ISelectBox<HtmlCodeTutorialSelectMultiplePage> Toppings
        {
            get { return new SelectBox<HtmlCodeTutorialSelectMultiplePage>(this, By.CssSelector("[name='toppings']")); }
        }
    }
}
