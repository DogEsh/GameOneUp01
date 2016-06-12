using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.SystemBase
{
    public delegate bool PredicateChange<T>(T old, T cur);
    public interface IConcurrentSingle<T>
    {
        void Set(T obj);
        T Get(bool flagReset = true);
        bool IsChanged { get; }
    }
}
