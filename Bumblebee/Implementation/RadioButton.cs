using Bumblebee.Extensions;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class RadioButton<TResult> : Option<TResult> where TResult : IBlock
	{
		public RadioButton(IBlock parent, By by) : base(parent, by)
		{
		}

		public RadioButton(IBlock parent, IWebElement element) : base(parent, element)
		{
		}

		public override string Text
		{
			get { return ParentBlock.Tag.FindElement(By.CssSelector("label[for=\"" + Tag.GetID() + "\"]")).Text; }
		}
	}
}
