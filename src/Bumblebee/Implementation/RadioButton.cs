using System;

using Bumblebee.Extensions;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class RadioButton<TResult> : Option<TResult> where TResult : IBlock
	{
		public RadioButton(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public RadioButton(IBlock parent, IWebElement element) : base(parent, element)
		{
		}

		public override string Text
		{
			get { return Parent.FindElement(By.CssSelector(String.Format("label[for=\"{0}\"]", Tag.GetID()))).Text; }
		}
	}
}
