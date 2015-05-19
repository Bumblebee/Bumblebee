using System;
using System.Diagnostics;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.KendoUI
{
	[DebuggerDisplay("KendoDatePicker {ToString}")]
	public class KendoDatePicker : TextField, IDateField
	{
		public KendoDatePicker(IBlock parent, By by) : base(parent, by)
		{
		}

		public KendoDatePicker(IBlock parent, IWebElement tag) : base(parent, tag)
		{
		}

		public TCustomResult EnterDate<TCustomResult>(DateTime date) where TCustomResult : IBlock
		{
			var executor = (IJavaScriptExecutor) Session.Driver;
			executor.ExecuteScript("return $(arguments[0]).data('kendoDatePicker').value(kendo.parseDate(arguments[1]));", Tag, date.ToString("yyyy-MM-dd"));
			return Session.CurrentBlock<TCustomResult>(ParentBlock.Tag);
		}

		public override TCustomResult EnterText<TCustomResult>(string text)
		{
			return AppendText<TCustomResult>(text, true);
		}

		public override TCustomResult AppendText<TCustomResult>(string text)
		{
			return AppendText<TCustomResult>(text, false);
		}

		private TCustomResult AppendText<TCustomResult>(string text, bool clear) where TCustomResult : IBlock
		{
			if (clear)
			{
				Tag.Clear();
			}

			var result = base.AppendText<TCustomResult>(text);
			EnsureValueIsUpdated();

			return result;
		}

		private void EnsureValueIsUpdated()
		{
			Tag.FindElement(By.XPath("../../../../..")).Click();
			Tag.Click();
		}

		public override string Text
		{
			get
			{
				var executor = (IJavaScriptExecutor) Session.Driver;
				return (string) executor.ExecuteScript("return kendo.toString($(arguments[0]).data('kendoDatePicker').value(), 'yyyy-MM-dd');", Tag);
			}
		}

		public DateTime? Value
		{
			get
			{
				DateTime result;
				return DateTime.TryParse(Text ?? String.Empty, out result) ? result : new DateTime?();
			}
		}

		public override string ToString()
		{
			return string.Format("Text: {0}, Value: {1}", Text, Value);
		}
	}

	[DebuggerDisplay("KendoDatePicker<T> {ToString}")]
	public class KendoDatePicker<TResult> : KendoDatePicker, IDateField<TResult>, ITextField<TResult>
		where TResult : IBlock
	{
		public KendoDatePicker(IBlock parent, By by) : base(parent, by)
		{
		}

		public KendoDatePicker(IBlock parent, IWebElement tag) : base(parent, tag)
		{
		}

		public TResult EnterDate(DateTime date)
		{
			return EnterDate<TResult>(date);
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
