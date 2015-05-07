using System;
using System.Globalization;

using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class NumericField : TextField, INumericField
	{
		public NumericField(IBlock parent, By by) : base(parent, by)
		{
		}

		public NumericField(IBlock parent, IWebElement tag) : base(parent, tag)
		{
		}

		public virtual TCustomResult EnterNumber<TCustomResult>(double number) where TCustomResult : IBlock
		{
			Tag.Clear();
			Tag.SendKeys(number.ToString(CultureInfo.CurrentUICulture));
			return Session.CurrentBlock<TCustomResult>(ParentBlock.Tag);
		}

		public virtual double? Value
		{
			get
			{
				double result;
				return Double.TryParse(Text ?? String.Empty, out result) ? result : new double?();
			}
		}
	}

	public class NumericField<TResult> : NumericField, INumericField<TResult> where TResult : IBlock
	{
		public NumericField(IBlock parent, By by) : base(parent, by)
		{
		}

		public NumericField(IBlock parent, IWebElement element) : base(parent, element)
		{
		}

		public virtual TResult EnterNumber(double number)
		{
			return EnterNumber<TResult>(number);
		}

		public TResult Press(Key key)
		{
			return Press<TResult>(key);
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
