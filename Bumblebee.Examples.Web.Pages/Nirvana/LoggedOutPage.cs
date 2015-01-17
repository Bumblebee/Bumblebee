using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
    public class LoggedOutPage : WebBlock
    {
        public LoggedOutPage(Session session) 
            : base(session)
        {}

        public ITextField<LoggedOutPage> Username
        {
            get { return new TextField<LoggedOutPage>(this, By.Id("username")); }
        }

        public ITextField<LoggedOutPage> Password
        {
            get { return new TextField<LoggedOutPage>(this, By.Id("password")); }
        }

        public IClickable Login
        {
            get { return new Clickable(this, By.ClassName("submit")); }
        }

        public IHasText Error
        {
           get { return new TextField(this, By.ClassName("formerror")); }
        }
    }
}
