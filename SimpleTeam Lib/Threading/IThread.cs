using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.Threading
{
    public interface IThread
    {
        void Start();
        void Close();
        ISteppable Stop();
        //void Pause();
    }
}
