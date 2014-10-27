using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.KendoUI
{
    public class KendoDropDownListOption : Element, IOption
    {
        public KendoDropDownListOption(IBlock parent, By by)
            : base(parent, by)
        {
        }

        public KendoDropDownListOption(IBlock parent, IWebElement element)
            : base(parent, element)
        {
        }
        
        public virtual TResult Click<TResult>() where TResult : IBlock
        {
            ParentBlock.Tag.FindElement(By.XPath("..")).Click();

            // Kendo animation may slow down the showing of the element.
            this.WaitUntil(x => x.Tag.Displayed);
            Tag.Click();
            return Session.CurrentBlock<TResult>(ParentBlock.Tag);
        }

        public override bool Selected
        {
            get
            {
                var selectedAttribute = Tag.GetAttribute("aria-selected");
                return selectedAttribute != null && selectedAttribute == "true";
            }
        }

        public override string Text
        {
            get { return Tag.GetTextFromHiddenElement(Session.Driver); }
        }
    }

    public class KendoDropDownListOption<T> : KendoDropDownListOption, IOption<T>
        where T : IBlock
    {
        public KendoDropDownListOption(IBlock parent, By by)
            : base(parent, by)
        {
        }

        public KendoDropDownListOption(IBlock parent, IWebElement element)
            : base(parent, element)
        {
        }

        public T Click()
        {
            return Click<T>();
        }
    }
}
