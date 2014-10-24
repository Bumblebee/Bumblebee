using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bumblebee.IntegrationTests.TestSupport.Pages;
using Bumblebee.Interfaces;
using Bumblebee.KendoUI;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.KendoUI.Pages
{
    public class KendoDropDownListDemoPage : WebBlock
    {
        public KendoDropDownListDemoPage(Session session)
            : base(session)
        {
        }

        public ISelectBox<KendoDropDownListDemoPage> Colors
        {
            get { return new KendoDropDownList<KendoDropDownListDemoPage>(this, By.Id("color")); }
        }
    }
}
