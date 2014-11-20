using Bumblebee.Examples.Web.Pages;
using Bumblebee.Interfaces;
using Bumblebee.KendoUI;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.KendoUI.Pages
{
    public class KendoDropDownListDemoPage : WebBlock
    {
        public const string Url = "http://demos.telerik.com/kendo-ui/dropdownlist/index";

        public KendoDropDownListDemoPage(Session session)
            : base(session)
        {
        }

        public ISelectBox<KendoDropDownListDemoPage> Colors
        {
            get { return new KendoDropDownList<KendoDropDownListDemoPage>(this, By.Id("color")); }
        }

        public ISelectBox Sizes
        {
            get { return new KendoDropDownList(this, By.Id("size")); }
        }
    }
}
