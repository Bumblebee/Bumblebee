using Bumblebee.Implementation;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
    public class SideBar : WebBlock
    {
        public SideBar(Session session) : base(session)
        {
            SetFinder(By.Id("east"));
        }

        public IWebElement Trash
        {
            get { return GetElement(By.ClassName("trash")); }
        }
    }
}