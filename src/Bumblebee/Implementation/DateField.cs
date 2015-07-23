using System;

using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class DateField : TextField, IDateField
	{
		public DateField(IBlock parent, By by) : base(parent, by)
		{
		}

		public DateField(IBlock parent, IWebElement tag) : base(parent, tag)
		{
		}

		public virtual TCustomResult EnterDate<TCustomResult>(DateTime date) where TCustomResult : IBlock
		{
			var executor = (IJavaScriptExecutor) Session.Driver;
			executor.ExecuteScript(String.Format("arguments[0].value = '{0:yyyy-MM-dd}';", date), Tag);

			return Session.CurrentBlock<TCustomResult>(ParentBlock.Tag);
		}

		public virtual DateTime? Value
		{
			get
			{
				DateTime result;
				return DateTime.TryParse(Text ?? String.Empty, out result) ? result : new DateTime?();
			}
		}
	}

	public class DateField<TResult> : DateField, IDateField<TResult>
		where TResult : IBlock
	{
		public DateField(IBlock parent, By by) : base(parent, by)
		{
		}

		public DateField(IBlock parent, IWebElement element) : base(parent, element)
		{
		}

		public virtual TResult EnterDate(DateTime date)
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
