using System;
using System.Drawing.Imaging;
using System.IO;

using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Bumblebee.Setup
{
	public class Session : IDisposable
	{
		private static readonly Type PageInterfaceType = typeof (IPage);

		private IBlock _currentBlock;

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

			return Page.Create<TPage>(this);
		}

		public virtual TPage NavigateTo<TPage>(string uriFormat, params object[] args) where TPage : IPage
		{
			return NavigateTo<TPage>(String.Format(uriFormat, args));
		}

		public virtual void Refresh()
		{
			Driver.Navigate().Refresh();
		}

		internal void SetCurrentBlock(IBlock block)
		{
			_currentBlock = block;
		}

		/// <summary>
		/// Retrieves the currently stored current block, if it is of type <typeparamref name="TBlock" />.
		/// Otherwise, if there is a current block, then the closest related element of type <typeparamref name="TBlock" /> is found.
		/// If type <typeparamref name="TBlock" /> is a <see cref="Bumblebee.Interfaces.IPage" /> then it is created and returned.
		/// Otherwise, null is returned.
		/// </summary>
		/// <typeparam name="TBlock"></typeparam>
		/// <returns></returns>
		public virtual TBlock CurrentBlock<TBlock>() where TBlock : IBlock
		{
			var type = typeof (TBlock);

			IBlock result = default (TBlock);

			if (type.IsInstanceOfType(_currentBlock))
			{
				result = (TBlock) _currentBlock;
			}
			else if (_currentBlock != null)
			{
				result = _currentBlock.FindRelated<TBlock>();
			}
			else if (PageInterfaceType.IsAssignableFrom(type))
			{
				result = Block.Create<TBlock>(this);
			}
			
			return (TBlock) result;
		}

		[Obsolete("This method is obsolete.  Due to the nature of lazy loading elements, this is no longer relevant.  For the same reason, we have removed the SpecificBlock type.  Please use the CurrentBlock<TBlock>() method to get your block reference.", error: true)]
		public virtual TBlock CurrentBlock<TBlock>(IWebElement tag) where TBlock : IBlock
		{
			return Block.Create<TBlock>(this);
		}

		/// <summary>
		/// Returns the page representation with the current <c ref="Session">Session</c>
		/// </summary>
		/// <remarks>
		/// There is nothing that currently enforces that the right type is being cast for the page, so if you select a different page
		/// than what was last navigated to, you might encounter errors when using the associated elements since they will likely not exist.
		/// </remarks>
		/// <typeparam name="TPage">The requested page type.</typeparam>
		/// <returns>A newly constructed page object of type <typeparamref name="TPage" />.</returns>
		public virtual TPage CurrentPage<TPage>() where TPage : IPage
		{
			return Page.Create<TPage>(this);
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
				screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
			}
			else if (String.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase)
					|| String.Equals(extension, ".jpeg", StringComparison.OrdinalIgnoreCase))
			{
				screenshot.SaveAsFile(path, ScreenshotImageFormat.Jpeg);
			}
			else if (String.Equals(extension, ".bmp", StringComparison.OrdinalIgnoreCase))
			{
				screenshot.SaveAsFile(path, ScreenshotImageFormat.Bmp);
			}
			else if (String.Equals(extension, ".gif", StringComparison.OrdinalIgnoreCase))
			{
				screenshot.SaveAsFile(path, ScreenshotImageFormat.Gif);
			}
			else
			{
				throw new ArgumentException("Unable to determine image format. The supported formats are BMP, GIF, JPEG and PNG.", "path");
			}

			return this;
		}

		public virtual void ExecuteJavaScript(string script, params object[] args)
		{
			Driver.ExecuteJavaScript<object>(script, args);
		}

		public virtual T ExecuteJavaScript<T>(string script, params object[] args)
		{
			return Driver.ExecuteJavaScript<T>(script, args);
		}

		~Session()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);

			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				// dispose managed resources

				End();
			}

			// dispose native resources
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
