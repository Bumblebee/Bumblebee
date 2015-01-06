using System.Collections.Generic;
using System.Linq;
using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
    public class TaskList : SpecificBlock
    {
        public TaskList(Session session, IWebElement tag) : base(session, tag)
        {}

        public string Name
        {
            get { return GetElement(By.ClassName("name")).Text;}
        }

        public IEnumerable<TaskRow> TaskRows
        {
            get
            {
                return GetElement(By.ClassName("tasks"))
                    .GetElements(By.ClassName("task"))
                    .Select(tag => new TaskRow(Session, tag));
            }
        }
    }
}