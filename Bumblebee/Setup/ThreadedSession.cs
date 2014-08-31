using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Setup
{
    /// <summary>
    /// Creates thread-safe instances of sessions.
    /// </summary>
    /// <typeparam name="TSession"></typeparam>
    public class Threaded<TSession> where TSession : Session
    {
        private static readonly ThreadLocal<TSession> _session = new ThreadLocal<TSession>();

        private static TSession CurrentSession
        {
            get { return _session.Value; }
            set { _session.Value = value; }
        }

        public static Session WithDriver<TDriverEnvironment>() where TDriverEnvironment : IDriverEnvironment, new()
        {
            if (CurrentSession != null)
            {
                CurrentSession.End();
                CurrentSession = null;
            }

            var type = typeof(TSession);
            IList<Type> constructorSignature = new List<Type> { typeof(IDriverEnvironment) };
            IList<object> constructorArgs = new List<object> { new TDriverEnvironment() };

            var constructor = type.GetConstructor(constructorSignature.ToArray());

            if (constructor == null)
            {
                throw new ArgumentException("The result type specified (" + type + ") is not a valid session.  " +
                                            "It must have a constructor that takes only an IDriverEnvironment.");
            }

            CurrentSession = constructor.Invoke(constructorArgs.ToArray()) as TSession;
            return CurrentSession;
        }

        public static TBlock CurrentBlock<TBlock>(IWebElement tag = null) where TBlock : IBlock
        {
            if (CurrentSession == null)
                throw new NullReferenceException("You cannot access the CurrentBlock without first initializing the Session by calling WithDriver<TDriverEnvironment>().");
            
            return CurrentSession.CurrentBlock<TBlock>();
        }

        internal static void Reset()
        {
            CurrentSession = null;
        }
    }
}
