using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages.Implementation
{
    public class WufooHtml5ExamplesPage : WebBlock
    {
        public WufooHtml5ExamplesPage(Session session)
            : base(session)
        {
        }

        public IDateField<WufooHtml5ExamplesPage> Date
        {
            get { return new DateField<WufooHtml5ExamplesPage>(this, By.CssSelector("input[type='date']")); }
        }

        public INumericField<WufooHtml5ExamplesPage> Number
        {
            get {  return new NumericField<WufooHtml5ExamplesPage>(this, By.CssSelector("input[type='number']"));}
        }

        public ITextField<WufooHtml5ExamplesPage> Placeholder
        {
            get {  return new TextField<WufooHtml5ExamplesPage>(this, By.Name("placeholder-test"));}
        }
    }
}
