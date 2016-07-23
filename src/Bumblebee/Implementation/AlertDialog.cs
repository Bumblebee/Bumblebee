using System;
using System.Collections.Generic;

using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Bumblebee.Specifications;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Bumblebee.Implementation
{
	public class AlertDialog : IAlertDialog
	{
		protected static readonly ISpecification By = new Specification();

		public IWebElement Tag { get; private set; }
		public IBlock Parent { get; private set; }
		public Session Session { get; private set; }

		private IAlert Alert { get; set; }

		public AlertDialog(Session session)
		{
			Session = session;

			Alert = WaitForAlert();
		}

		public AlertDialog(IBlock parent) : this(parent.Session)
		{
			Parent = parent;
		}

		public TParent ParentAs<TParent>() where TParent : IBlock
		{
			var type = typeof (TParent);

			var result = default (TParent);

			if (type.IsInstanceOfType(Parent))
			{
				result = (TParent)Parent;
			}

			return result;
		}

		public IWebElement FindElement(By @by)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<IWebElement> FindElements(By @by)
		{
			throw new NotImplementedException();
		}

		private IAlert WaitForAlert()
		{
			var wait = new WebDriverWait(Session.Driver, TimeSpan.FromSeconds(5));
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
