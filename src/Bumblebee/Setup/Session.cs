using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
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

		public virtual TBlock NavigateTo<TBlock>(string url) where TBlock : IBlock
		{
			Driver.Navigate().GoToUrl(url);
			return CurrentBlock<TBlock>();
		}

		public virtual TBlock CurrentBlock<TBlock>(IWebElement tag = null) where TBlock : IBlock
		{
			var type = typeof (TBlock);
			IList<Type> constructorSignature = new List<Type> { typeof (Session) };
			IList<object> constructorArgs = new List<object> { this };

			if (typeof (ISpecificBlock).IsAssignableFrom(typeof (TBlock)))
			{
				constructorSignature.Add(typeof (IWebElement));
				constructorArgs.Add(tag);
			}

			var constructor = type.GetConstructor(constructorSignature.ToArray());

			if (constructor == null)
			{
				throw new ArgumentException(String.Format("The result type specified ({0}) is not a valid block. It must have a constructor that takes only a session.", type));
			}

			return (TBlock) constructor.Invoke(constructorArgs.ToArray());
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
			else if ((String.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase))
					|| (String.Equals(extension, ".jpeg", StringComparison.OrdinalIgnoreCase)))
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
