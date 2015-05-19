using Bumblebee.Implementation;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages.Implementation
{
	public class ComplexTableRow : Element
	{
		public ComplexTableRow(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public ComplexTableRow(IBlock parent, IWebElement tag) : base(parent, tag)
		{
		}

		public IClickable<TablePage> TablePageLink
		{
			get { return new Clickable<TablePage>(this, By.ClassName("table-link")); }
		}

		public IClickable<RadioButtonsPage> RadioButtonPageLink
		{
			get { return new Clickable<RadioButtonsPage>(this, By.ClassName("radio-link")); }
		}
	}
}
