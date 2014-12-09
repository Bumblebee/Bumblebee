using System;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages.Implementation
{
    public class GenericTablePage : WebBlock
    {
        public GenericTablePage(Session session) : base(session)
        {
        }

        public GenericTablePage(Session session, TimeSpan timeout) : base(session, timeout)
        {
        }

        public ITable<GenericTableRow> Table
        {
            get { return new Table<GenericTableRow>(this, By.Id("DataGrid")); }
        }
    }
}
