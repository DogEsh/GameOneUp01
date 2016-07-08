using System.Threading;

namespace SimpleTeam.Threading
{
    /**
    <summary>
    Нить уходящая в сон.
    </summary>
    */

    public class ThreadSleepy : IThread
    {
        private AutoResetEvent _event;
        private volatile bool _isExit;

        private ISteppable _steppable;
        private int _timeSleep;

        private Thread _mainThread;
        private object _stopSync = new object();
        private bool _isStopped;

        public ThreadSleepy(ISteppable steppable, int timeSleep)
        {
            _event = new AutoResetEvent(false);

            _mainThread = new Thread(Go);
            _isStopped = false;

            _steppable = steppable;
            _timeSleep = timeSleep;
        }
        public void Start()
        {
            lock (_stopSync)
            {
                if (_isStopped) return;

                lock (_event)
                {
                    if (_mainThread.IsAlive) return;
                    _isExit = false;
                    _event.Reset();
                    _mainThread.Start();
                }
            }
        }
        public void Close()
        {
            
            bool ok = TryStop();
            if (ok)
            {
                _steppable.Destroy();
            }
        }
        public ISteppable Stop()
        {
            bool ok = TryStop();
            if (ok)
            {
                return _steppable;
            }
            else return null;
        }
        private bool TryStop()
        {
            lock (_stopSync)
            {
                if (_isStopped) return false;
                if (_mainThread.IsAlive)
                {
                    lock (_event)
                    {
                        _isExit = true;
                        _event.Set();
                        _mainThread.Join();
                    }
                }
                _isStopped = true;
            }
            return true;
        }
        private void Go()
        { 
            while (!_isExit)
            {
                _event.WaitOne(_timeSleep);
                bool notOk = !_steppable.Step();
                if (notOk) _isExit = notOk;
            }
        }
    }
}