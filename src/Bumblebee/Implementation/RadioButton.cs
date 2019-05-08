using Bumblebee.Extensions;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class RadioButton<TResult> : Option<TResult>
		where TResult : IBlock
	{
		public RadioButton(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public override string Text => Parent.FindElement(By.CssSelector($"label[for=\"{Tag.GetId()}\"]")).Text;
	}
}
