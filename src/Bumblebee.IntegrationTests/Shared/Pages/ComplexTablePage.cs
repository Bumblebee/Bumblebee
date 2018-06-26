using System;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class ComplexTablePage : Page
	{
		public ComplexTablePage(Session session) : base(session)
		{
		}

		public ComplexTablePage(Session session, TimeSpan timeout) : base(session, timeout)
		{
		}

		public ITable Table
		{
			get { return new Table(this, By.Id("DataGrid")); }
		}
	}
}
