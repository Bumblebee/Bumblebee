using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Bumblebee
{
    public class AlertDialog : Block
    {
        private IWebElement Parent { get; set; }
        private IAlert Alert { get; set; }

        public AlertDialog(Session session) : base(session)
        {
            Parent = null;
            Alert = Session.Driver.SwitchTo().Alert();
        }

        public AlertDialog(IWebElement parent, Session session) : base(session)
        {
            Parent = parent;
            Alert = Session.Driver.SwitchTo().Alert();
        }

        public TResult Accept<TResult>() where TResult : Block
        {
            Alert.Accept();
            return Session.CurrentBlock<TResult>(Parent);
        }

        public TResult Dismiss<TResult>() where TResult : Block
        {
            Alert.Dismiss();
            return Session.CurrentBlock<TResult>(Parent);
        }

        public AlertDialog EnterText(string text)
        {
            Alert.SendKeys(text);
            return this;
        }

        public string Text
        {
            get { return Alert.Text; }
        }
    }
}
