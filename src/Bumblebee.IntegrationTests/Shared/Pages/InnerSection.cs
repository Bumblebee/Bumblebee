using Bumblebee.Implementation;
using Bumblebee.Interfaces;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class InnerSection : Block
	{
		public InnerSection(IBlock parent)
			: base(parent, By.Id("innerSection"))
		{
		}

		public string SpanText
		{
			get
			{
				return Tag
					.FindElement(By.Name("span"))
					.Text ;
			}
		}

		public InnerInnerSection InnerInnerSection
		{
			get {  return new InnerInnerSection(this); }
		}
	}
}