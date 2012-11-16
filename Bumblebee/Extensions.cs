using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.UI;
using Bumblebee.UI.Generic;
using OpenQA.Selenium;

namespace Bumblebee
{
    public static class Extensions
    {
        public static IEnumerable<TUIElement> WithText<TUIElement>(this IEnumerable<TUIElement> uiElements, string text) where TUIElement : IUIElement
        {
            return uiElements.Where(uiElement => uiElement.Text == text);
        }

        public static TUIElement FirstWithText<TUIElement>(this IEnumerable<TUIElement> uiElements, string text) where TUIElement : IUIElement
        {
            return uiElements.First(uiElement => uiElement.Text == text);
        }

        public static string GetID(this IWebElement element)
        {
            return element.GetAttribute("id");
        }
    }
}
