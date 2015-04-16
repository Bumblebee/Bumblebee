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

		public TResult EnterDate<TResult>(DateTime date) where TResult : IBlock
		{
			var executor = (IJavaScriptExecutor) Session.Driver;

			executor.ExecuteScript("return $(arguments[0]).data('kendoDatePicker').value(kendo.parseDate(arguments[1]));", Tag, date.ToString("yyyy-MM-dd"));

			return FindRelated<TResult>();
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
			if (clear)
			{
				Tag.Clear();
			}

			var result = base.AppendText<TResult>(text);
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
