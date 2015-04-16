using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.KendoUI
{
	[DebuggerDisplay("KendoNumericTextBox {ToString}")]
	public class KendoNumericTextBox : TextField, INumericField
	{
		public KendoNumericTextBox(IBlock parent, By by) : base(parent, by)
		{
		}

		public KendoNumericTextBox(IBlock parent, IWebElement tag) : base(parent, tag)
		{
		}

		private IWebElement GetFakeElement()
		{
			return Tag.FindElement(By.XPath("..")).FindElements(By.TagName("input")).First();
		}

		public TResult EnterNumber<TResult>(double number) where TResult : IBlock
		{
			return EnterText<TResult>(number.ToString(CultureInfo.CurrentUICulture));
		}

		public override TResult EnterText<TResult>(string text)
		{
			return AppendText<TResult>(text, true);
		}

		public override TResult AppendText<TResult>(string text)
		{
			return AppendText<TResult>(text, false);
		}

		private TResult AppendText<TResult>(string text, bool clear) where TResult : IBlock
		{
			var fakeElement = GetFakeElement();

			fakeElement.Click();

			if (clear)
			{
				Tag.Clear();
			}

			Tag.SendKeys(text);

			EnsureValueIsUpdated(fakeElement);

			return FindRelated<TResult>();
		}

		private void EnsureValueIsUpdated(IWebElement fakeElement)
		{
			Tag.FindElement(By.XPath("../../../..")).Click();
			fakeElement.Click();
		}

		public override string Text
		{
			get { return GetFakeElement().GetAttribute("value"); }
		}

		public double? Value
		{
			get
			{
				double result;
				return double.TryParse(Tag.GetAttribute("value") ?? String.Empty, NumberStyles.Any, CultureInfo.CurrentUICulture, out result) ? result : new double?();
			}
		}

		public override string ToString()
		{
			return String.Format("Text: {0}, Value: {1}", Text, Value);
		}
	}

	[DebuggerDisplay("KendoNumericTextBox<T> {ToString}")]
	public class KendoNumericTextBox<TResult> : KendoNumericTextBox, INumericField<TResult>, ITextField<TResult>
		where TResult : IBlock
	{
		public KendoNumericTextBox(IBlock parent, By by) : base(parent, by)
		{
		}

		public KendoNumericTextBox(IBlock parent, IWebElement tag) : base(parent, tag)
		{
		}

		public TResult EnterNumber(double number)
		{
			return EnterNumber<TResult>(number);
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
