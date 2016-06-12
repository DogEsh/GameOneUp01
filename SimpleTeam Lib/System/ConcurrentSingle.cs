using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.SystemBase
{
    public class ConcurrentSingle<T> : IConcurrentSingle<T>
    {
        PredicateChange<T> _pred;
        private T _obj;
        private object _locker;
        private bool _isChanged;
        public bool IsChanged
        {
            get
            {
                return _isChanged;
            }
        }

        public ConcurrentSingle(PredicateChange<T> pred)
        {
            _locker = new object();
            _isChanged = false;
            _obj = default(T);
            _pred = pred;
        }
        public T Get(bool flagReset = true)
        {
            T obj;
            lock (_locker)
            {
                obj = _obj;
                _isChanged = _isChanged & !flagReset;
            }
            return obj;
        }

        public void Set(T obj)
        {
            lock (_locker)
            {
                _obj = obj;
                _isChanged = _isChanged | _pred(_obj, obj);
            }
        }
    }
}
