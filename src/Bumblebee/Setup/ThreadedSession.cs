using System;
using System.Linq;
using System.Threading;

using Bumblebee.Interfaces;

namespace Bumblebee.Setup
{
	/// <summary>
	/// Creates thread-safe instances of sessions.
	/// </summary>
	/// <typeparam name="TSession"></typeparam>
	public static class Threaded<TSession>
		where TSession : Session
	{
		public const string InvalidSessionTypeFormat = "The instance type specified ({0}) is not a valid session.  It must have a constructor that takes an IDriverEnvironment and/or ISettings.";

		private static readonly ThreadLocal<TSession> ThreadLocalSession = new ThreadLocal<TSession>();

		private static TSession Current
		{
			get { return ThreadLocalSession.Value; }
			set { ThreadLocalSession.Value = value; }
		}

		/// <summary>
		/// Allows the creation of a Session-based type using a type derived from IDriverEnvironment that the system can initialize with a parameterless constructor.
		/// </summary>
		/// <typeparam name="TDriverEnvironment"></typeparam>
		/// <returns></returns>
		public static TSession With<TDriverEnvironment>() where TDriverEnvironment : IDriverEnvironment, new()
		{
			return With(new TDriverEnvironment());
		}

		public static TSession With<TDriverEnvironment>(ISettings settings) where TDriverEnvironment : IDriverEnvironment, new()
		{
			return With(new TDriverEnvironment(), settings);
		}

		/// <summary>
		/// Allows the creation of a Session-based type using an instance of a type of IDriverEnvironment.
		/// </summary>
		/// <param name="environment"></param>
		/// <returns></returns>
		public static TSession With(IDriverEnvironment environment)
		{
			if (Current != null)
			{
				Current.End();
				Current = null;
			}

			Current = GetInstanceOf<TSession>(environment);

			return Current;
		}

		public static TSession With(IDriverEnvironment environment, ISettings settings)
		{
			if (Current != null)
			{
				Current.End();
				Current = null;
			}

			Current = GetInstanceOf<TSession>(environment, settings);
			return Current;
		}

		private static T GetInstanceOf<T>(params object[] constructorArgs) where T : Session
		{
			var type = typeof (T);

			var constructorSignature = constructorArgs
				.Select(arg => arg.GetType())
				.ToArray();
			
			var constructor = type.GetConstructor(constructorSignature);

			if (constructor == null)
			{
				var message = String.Format(InvalidSessionTypeFormat, type);

				throw new ArgumentException(message);
			}

			return constructor.Invoke(constructorArgs.ToArray()) as T;
		}

		public static TBlock CurrentBlock<TBlock>() where TBlock : IBlock
		{
			if (Current == null)
			{
				throw new NullReferenceException("You cannot access the current block without first initializing the Session by calling With<TDriverEnvironment>().");
			}

			return Current.CurrentBlock<TBlock>();
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
		public static TPage CurrentPage<TPage>() where TPage : IPage
		{
			if (Current == null)
			{
				throw new NullReferenceException("You cannot access the current page without first initializing the Session by calling With<TDriverEnvironment>().");
			}

			return Current.CurrentPage<TPage>();
		}

		public static void End()
		{
			if (Current != null)
			{
				Current.End();

				Current = null;
			}
		}
	}
}
