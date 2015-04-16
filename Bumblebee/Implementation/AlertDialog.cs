using System;

using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Bumblebee.Implementation
{
	public class AlertDialog : IAlertDialog
	{
		public IWebElement Tag { get; private set; }
		public IBlock ParentBlock { get; private set; }
		public Session Session { get; private set; }

		private IAlert Alert { get; set; }

		public AlertDialog(Session session)
		{
			Session = session;
			Alert = WaitForAlert();
		}

		public AlertDialog(IBlock parent) : this(parent.Session)
		{
			ParentBlock = parent;
		}

		private IAlert WaitForAlert()
		{
			var wait = new WebDriverWait(Session.Driver, new TimeSpan(0, 0, 5));
			return wait.Until(d => d.SwitchTo().Alert());
		}

		public virtual TResult Accept<TResult>() where TResult : IBlock
		{
			Alert.Accept();

			return Session.CurrentBlock<TResult>();
		}

		public virtual TResult Dismiss<TResult>() where TResult : IBlock
		{
			Alert.Dismiss();

			return Session.CurrentBlock<TResult>();
		}

		public virtual IAlertDialog EnterText(string text)
		{
			Alert.SendKeys(text);
			return this;
		}

		public virtual string Text
		{
			get { return Alert.Text; }
		}

		public IPerformsDragAndDrop GetDragAndDropPerformer()
		{
			throw new NotImplementedException();
		}

		public void VerifyMonkeyState()
		{
			throw new NotImplementedException();
		}
	}
}
