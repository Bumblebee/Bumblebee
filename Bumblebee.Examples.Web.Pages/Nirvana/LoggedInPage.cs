using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
    public class LoggedInPage : WebBlock
    {
        public LoggedInPage(Session session)
            : base(session)
        {
            Wait.Until(driver => driver.GetElement(By.Id("north")));
            Tag = Session.Driver.GetElement(By.TagName("body"));
        }

        public ToolBar ToolBar
        {
            get { return new ToolBar(Session); }
        }

        public SideBar SideBar
        {
            get { return new SideBar(Session); }
        }

        public MainArea MainArea
        {
            get { return new MainArea(Session);}
        }
    }
}