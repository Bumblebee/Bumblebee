using System.Threading;

namespace Bumblebee.Setup
{
    public class Session<T> where T : IDriverEnvironment, new()
    {
        private static readonly ThreadLocal<Session> _threadLocalSession = new ThreadLocal<Session>();
        private static readonly object PadLock = new object();

        private Session()
        { }

        public static Session Current
        {
            get
            {
                lock (PadLock)
                {
                    return _threadLocalSession.Value ?? (_threadLocalSession.Value = new Session(new T()));
                }
            }
        }
    }
}
