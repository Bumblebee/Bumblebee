using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class TextField : Element, ITextField
	{
		public TextField(IBlock parent, By by) : base(parent, by)
		{
		}

		public TextField(IBlock parent, IWebElement tag) : base(parent, tag)
		{
		}

		public virtual TResult EnterText<TResult>(string text) where TResult : IBlock
		{
			Tag.Clear();

			return AppendText<TResult>(text);
		}

		public virtual TResult AppendText<TResult>(string text) where TResult : IBlock
		{
			Tag.SendKeys(text);

			return FindRelated<TResult>();
		}

		public override string Text
		{
			get { return Tag.GetAttribute("value"); }
		}
	}

	public class TextField<TResult> : TextField, ITextField<TResult> where TResult : IBlock
	{
		public TextField(IBlock parent, By by) : base(parent, by)
		{
		}

		public TextField(IBlock parent, IWebElement element) : base(parent, element)
		{
		}

		public virtual TResult EnterText(string text)
		{
			return EnterText<TResult>(text);
		}

		public virtual TResult AppendText(string text)
		{
			return AppendText<TResult>(text);
		}
	}
}
