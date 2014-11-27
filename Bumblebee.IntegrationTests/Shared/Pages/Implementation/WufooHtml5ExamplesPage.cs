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
    public class WufooHtml5ExamplesPage : WebBlock
    {
        public const string Url = "http://www.wufoo.com/html5/example/";

        public WufooHtml5ExamplesPage(Session session)
            : base(session)
        {
        }

        public IDateField<WufooHtml5ExamplesPage> Date
        {
            get { return new DateField<WufooHtml5ExamplesPage>(this, By.Name("datetime-test")); }
        }

        public INumericField<WufooHtml5ExamplesPage> Number
        {
            get { return new NumericField<WufooHtml5ExamplesPage>(this, By.Name("number-test")); }
        }
    }
}
