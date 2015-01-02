using System.Collections.Generic;
using System.Linq;
using Bumblebee.Implementation;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
    public class MainArea : WebBlock
    {
        public MainArea(Session session) : base(session)
        {
            SetFinder(By.Id("main"));
        }

        public IEnumerable<TaskList> TaskLists
        {
            get { return GetElements(By.ClassName("tasklist"))
                .Select(x => new TaskList(Session, x)); }
        }
    }
}