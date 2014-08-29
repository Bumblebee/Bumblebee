using System.Threading;

namespace Bumblebee.Setup
{
    public class Session<TDriverEnvironment> where TDriverEnvironment : IDriverEnvironment, new()
    {
        private static readonly ThreadLocal<Session> _session = new ThreadLocal<Session>();

        private Session()
        {}

        public static Session Current
        {
            get { return _session.Value ?? (_session.Value = new Session(new TDriverEnvironment())); }
        }
        
        public static void Reset()
        {
            _session.Value.End();
            _session.Value = null;
        }
    }
}
