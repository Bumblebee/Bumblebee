using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.KendoUI
{
    public class KendoNumericTextBox : Element, INumericField
    {
        public KendoNumericTextBox(IBlock parent, By by)
            : base(parent, by)
        {
        }

        public KendoNumericTextBox(IBlock parent, IWebElement tag)
            : base(parent, tag)
        {
        }

        private IWebElement GetFakeElement()
        {
            return Tag.FindElement(By.XPath("..")).FindElements(By.TagName("input")).First();
        }

        public TCustomResult EnterNumber<TCustomResult>(double number) where TCustomResult : IBlock
        {
            var fakeElement = GetFakeElement();
            fakeElement.Click();
            Tag.Clear();
            Tag.SendKeys(number.ToString(CultureInfo.CurrentUICulture));

            // Have to click a parent, then re-click for the value to be updated.
            Tag.FindElement(By.XPath("../../../..")).Click();
            fakeElement.Click();
            return Session.CurrentBlock<TCustomResult>(ParentBlock.Tag);
        }

        public override string Text
        {
            get
            {
                return GetFakeElement().GetAttribute("value");
            }
        }

        public double? Value
        {
            get
            {
                double result;
                return double.TryParse(Tag.GetAttribute("value") ?? string.Empty, NumberStyles.Any, CultureInfo.CurrentUICulture, out result) ? result : new double?();
            }
        }
    }

    public class KendoNumericTextBox<TResult> : KendoNumericTextBox, INumericField<TResult>
        where TResult : IBlock
    {
        public KendoNumericTextBox(IBlock parent, By by)
            : base(parent, by)
        {
        }

        public KendoNumericTextBox(IBlock parent, IWebElement tag)
            : base(parent, tag)
        {
        }

        public TResult EnterNumber(double number)
        {
            return EnterNumber<TResult>(number);
        }
    }
}
