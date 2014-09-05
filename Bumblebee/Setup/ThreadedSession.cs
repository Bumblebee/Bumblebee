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

        /// <summary>
        /// Allows the creation of a Session-based type using a type derived from IDriverEnvironment that the system can initialize with a parameterless constructor.
        /// </summary>
        /// <typeparam name="TDriverEnvironment"></typeparam>
        /// <returns></returns>
        public static TSession With<TDriverEnvironment>() where TDriverEnvironment : IDriverEnvironment, new()
        {
            return With(new TDriverEnvironment());
        }

        /// <summary>
        /// Allows the creation of a Session-based type using an instance of a type of IDriverEnvironment.
        /// </summary>
        /// <typeparam name="TDriverEnvironment"></typeparam>
        /// <param name="environment"></param>
        /// <returns></returns>
        public static TSession With<TDriverEnvironment>(TDriverEnvironment environment)
            where TDriverEnvironment : IDriverEnvironment
        {
            if (CurrentSession != null)
            {
                CurrentSession.End();
                CurrentSession = null;
            }

            var type = typeof(TSession);
            IList<Type> constructorSignature = new List<Type> { typeof(IDriverEnvironment) };
            IList<object> constructorArgs = new List<object> { environment };

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
                throw new NullReferenceException("You cannot access the CurrentBlock without first initializing the Session by calling With<TDriverEnvironment>().");
            
            return CurrentSession.CurrentBlock<TBlock>();
        }

        public static void End()
        {
            if (CurrentSession == null) return;

            CurrentSession.End();
            CurrentSession = null;
        }
    }
}
