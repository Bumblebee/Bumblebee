using Bumblebee.Interfaces;
using Bumblebee.KendoUI;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages.KendoUI
{
    public class KendoDatePickerDemoPage : WebBlock
    {
        public KendoDatePickerDemoPage(Session session)
            : base(session)
        {
        }

        public IDateField<KendoDatePickerDemoPage> DateFrom
        {
            get { return new KendoDatePicker<KendoDatePickerDemoPage>(this, By.Id("datepicker")); }
        }
    }
}
