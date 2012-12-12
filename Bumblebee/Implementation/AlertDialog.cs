using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
    public class AlertDialog : Block, IAlertDialog
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

        public TResult Accept<TResult>() where TResult : IBlock
        {
            Alert.Accept();
            return Session.CurrentBlock<TResult>(Parent);
        }

        public TResult Dismiss<TResult>() where TResult : IBlock
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
