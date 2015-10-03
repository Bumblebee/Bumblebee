using Bumblebee.Implementation;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class ComplexTableRow : Block
	{
		public ComplexTableRow(IBlock parent, By @by) : base(parent, @by)
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
