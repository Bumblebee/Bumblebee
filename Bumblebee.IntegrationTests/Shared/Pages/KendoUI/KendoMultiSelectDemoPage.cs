using System;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.KendoUI;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages.KendoUI
{
    public class KendoMultiSelectDemoPage : WebBlock
    {
        public KendoMultiSelectDemoPage(Session session)
            : base(session, TimeSpan.FromSeconds(10))
        {
        }

        public ISelectBox<KendoMultiSelectDemoPage> Movies
        {
            get { return new KendoMultiSelect<KendoMultiSelectDemoPage>(this, By.Id("movies")); }
        }
    }
}
