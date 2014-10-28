using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.KendoUI
{
    [DebuggerDisplay("KendoDatePicker {ToString}")]
    public class KendoDatePicker : Element, IDateField
    {
        public KendoDatePicker(IBlock parent, By by)
            : base(parent, by)
        {
        }

        public KendoDatePicker(IBlock parent, IWebElement tag)
            : base(parent, tag)
        {
        }

        public TCustomResult EnterDate<TCustomResult>(DateTime date) where TCustomResult : IBlock
        {
            var executor = (IJavaScriptExecutor)Session.Driver;
            executor.ExecuteScript("return $(arguments[0]).data('kendoDatePicker').value(kendo.parseDate(arguments[1]));", Tag, date.ToString("yyyy-MM-dd"));
            return Session.CurrentBlock<TCustomResult>(ParentBlock.Tag);
        }

        public override string Text
        {
            get
            {
                var executor = (IJavaScriptExecutor)Session.Driver;
                return (string)executor.ExecuteScript("return kendo.toString($(arguments[0]).data('kendoDatePicker').value(), 'yyyy-MM-dd');", Tag);
            }
        }

        public DateTime? Value
        {
            get
            {
                DateTime result;
                return DateTime.TryParse(Text ?? string.Empty, out result) ? result : new DateTime?();
            }
        }

        public override string ToString()
        {
            return string.Format("Text: {0}, Value: {1}", Text, Value);
        }
    }

    [DebuggerDisplay("KendoDatePicker<T> {ToString}")]
    public class KendoDatePicker<TResult> : KendoDatePicker, IDateField<TResult>
        where TResult : IBlock
    {
        public KendoDatePicker(IBlock parent, By by)
            : base(parent, by)
        {
        }

        public KendoDatePicker(IBlock parent, IWebElement tag)
            : base(parent, tag)
        {
        }

        public TResult EnterDate(DateTime date)
        {
            return EnterDate<TResult>(date);
        }
    }
}
