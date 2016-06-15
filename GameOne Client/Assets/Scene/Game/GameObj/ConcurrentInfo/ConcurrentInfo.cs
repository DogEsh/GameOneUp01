using System.Collections.Generic;

namespace SimpleTeam.GameOne.GameInfo
{
    class ConcurrentInfo<T> : IConcurrentInfo<T>
    {
        T _info;
        HelperStateInfo _state;
        object _locker;
        public ConcurrentInfo()
        {
            _info = default(T);
            _state = HelperStateInfo.None;
            _locker = new object();
        }

        public void SetInfo(T info, HelperStateInfo state)
        {
            lock (_locker)
            {
                _info = info;
                if (_state < state)
                {
                    _state = state;
                }
            }
        }
        public KeyValuePair<HelperStateInfo, T> GetInfo(bool flagReset = false)
        {
            KeyValuePair<HelperStateInfo, T> pair;
            
            lock (_locker)
            {
                pair = new KeyValuePair<HelperStateInfo, T>(_state, _info);
                if (flagReset) _state = HelperStateInfo.None;
            }
            return pair;
        }
        public HelperStateInfo GetState()
        {
            HelperStateInfo state;
            lock (_locker)
            {
                state = _state;
            }
            return state;
        }
    }
}
