using System;
using System.Drawing.Imaging;
using System.IO;

using Bumblebee.Extensions;
using Bumblebee.Interfaces;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Bumblebee.Setup
{
	public class Session
	{
		public virtual ISettings Settings { get; private set; }

		public virtual IWebDriver Driver { get; private set; }

		public virtual IMonkey Monkey { get; protected set; }

		public Session(IDriverEnvironment environment) : this(environment, new Settings())
		{
		}

		public Session(IDriverEnvironment environment, ISettings settings)
		{
			Settings = settings;
			Driver = environment.CreateWebDriver();
		}

		public virtual TPage NavigateTo<TPage>(string url) where TPage : IPage
		{
			Driver.Navigate().GoToUrl(url);
			return CurrentBlock<TPage>();
		}

		public virtual TPage NavigateTo<TPage>(string uriFormat, params object[] args) where TPage : IPage
		{
			return NavigateTo<TPage>(string.Format(uriFormat, args));
		}

		private IBlock _currentBlock;

		public void SetCurrentBlock(IBlock block)
		{
			_currentBlock = block;
		}

		public virtual TBlock CurrentBlock<TBlock>() where TBlock : IBlock
		{
			IBlock block = null;

			if (_currentBlock is TBlock)
			{
				block = (TBlock) _currentBlock;
			}
			else if (_currentBlock != null)
			{
				block = _currentBlock.FindRelated<TBlock>();
			}

			if (block == null)
			{
				block = Factory.CreateBlockFromSession<TBlock>(this);
			}
			
			return (TBlock) block;
		}

		//[Obsolete("This method is obsolete.  Due to the nature of lazy loading elements, this is no longer relevant.  For the same reason, we have removed the SpecificBlock type.  Please use the CurrentBlock<TBlock>() method to get your block reference.", error: true)]
		public virtual TBlock CurrentBlock<TBlock>(IWebElement tag) where TBlock : IBlock
		{
			return Factory.CreateBlockFromSession<TBlock>(this);
		}

		/// <summary>
		/// Returns the a page reprentation with the current <c ref="Session">Session</c>
		/// </summary>
		/// <remarks>
		/// There is nothing that currently enforces that the right type is being cast for the page, so if you select a different page
		/// than what was last navigated to, you might encounter errors when using the associated elements since they will likely not exist.
		/// </remarks>
		/// <typeparam name="TPage"></typeparam>
		/// <returns></returns>
		public virtual TPage CurrentPage<TPage>() where TPage : IPage
		{
			return Factory.CreateBlockFromSession<TPage>(this);
		}

		public virtual void End()
		{
			if (Driver != null)
			{
				Driver.Quit();

				Driver.Dispose();

				Driver = null;
			}
		}

		public virtual Session CaptureScreen()
		{
			var filename = String.Format("{0}.png", CallStack.GetCallingMethod().GetFullName());
			var path = Path.Combine(Settings.ScreenCapturePath, filename);
			return CaptureScreen(path);
		}

		public virtual Session CaptureScreen(string path)
		{
			var screenshot = Driver.TakeScreenshot();

			var extension = Path.GetExtension(path);

			if (String.Equals(extension, ".png", StringComparison.OrdinalIgnoreCase))
			{
				screenshot.SaveAsFile(path, ImageFormat.Png);
			}
			else if ((String.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase))
					|| (String.Equals(extension, ".jpeg", StringComparison.OrdinalIgnoreCase)))
			{
				screenshot.SaveAsFile(path, ImageFormat.Jpeg);
			}
			else if (String.Equals(extension, ".bmp", StringComparison.OrdinalIgnoreCase))
			{
				screenshot.SaveAsFile(path, ImageFormat.Bmp);
			}
			else if (String.Equals(extension, ".gif", StringComparison.OrdinalIgnoreCase))
			{
				screenshot.SaveAsFile(path, ImageFormat.Gif);
			}
			else
			{
				throw new ArgumentException("Unable to determine image format. The supported formats are BMP, GIF, JPEG and PNG.", "path");
			}

			return this;
		}

		public virtual T ExecuteJavaScript<T>(string script, params object[] args)
		{
			return Driver.ExecuteJavaScript<T>(script, args);
		}
	}

	public class Session<TDriverEnvironment> : Session
		where TDriverEnvironment : IDriverEnvironment, new()
	{
		public Session() : base(new TDriverEnvironment())
		{
		}

		public Session(ISettings settings) : base(new TDriverEnvironment(), settings)
		{
		}
	}
}
