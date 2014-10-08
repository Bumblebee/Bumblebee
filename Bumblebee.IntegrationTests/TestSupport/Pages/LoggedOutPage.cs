using Bumblebee.Setup;
using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.TestSupport.Pages
{
    public class LoggedOutPage : WebBlock
    {
        public LoggedOutPage(Session session)
            : base(session)
        {
            Tag = GetElement(By.Id("login"));
        }
    }
}
