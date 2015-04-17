using System;
using System.Collections.Generic;
using System.Linq;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Setup
{
	public class Session
	{
		public IWebDriver Driver { get; private set; }

		public IMonkey Monkey { get; protected set; }

		public Session(IDriverEnvironment environment)
		{
			Driver = environment.CreateWebDriver();
		}

		public TBlock NavigateTo<TBlock>(string url) where TBlock : IBlock
		{
			Driver.Navigate().GoToUrl(url);
			return CurrentBlock<TBlock>();
		}

		public TBlock CurrentBlock<TBlock>() where TBlock : IBlock
		{
			return Factory.CreateBlockFromSession<TBlock>(this);
		}

		public void End()
		{
			if (Driver != null)
			{
				Driver.Quit();

				Driver.Dispose();

				Driver = null;
			}
		}
	}

	public class Session<TDriverEnvironment> : Session
		where TDriverEnvironment : IDriverEnvironment, new()
	{
		public Session()
			: base(new TDriverEnvironment())
		{
		}
	}
}
