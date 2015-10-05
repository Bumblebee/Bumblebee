using Bumblebee.Implementation;
using Bumblebee.Interfaces;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class InnerInnerSection : Block
	{
		public InnerInnerSection(IBlock parent)
			: base(parent, By.Id("innerInnerSection"))
		{
		}

		public ITextField TextBox
		{
			get { return new TextField(this, By.Id("textbox")); }
		}
	}
}