using System;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages.Implementation
{
    public class ComplexTablePage : WebBlock
    {
        public ComplexTablePage(Session session) : base(session)
        {
        }

        public ComplexTablePage(Session session, TimeSpan timeout) : base(session, timeout)
        {
        }

        public ITable<ComplexTableRow> Table
        {
            get
            {
                return new Table<ComplexTableRow>(this, By.Id("DataGrid"));
            }
        }
    }
}
