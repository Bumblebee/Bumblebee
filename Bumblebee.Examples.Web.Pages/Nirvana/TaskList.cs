using System.Collections.Generic;
using System.Linq;
using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
    public class TaskList : SpecificBlock
    {
        public TaskList(IBlock parent, By by) : base(parent, by)
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
                    .Select(tag => new TaskRow(ParentBlock, tag));
            }
        }
    }
}