using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.Threading
{
    public interface ISteppable
    {
        bool Step();
        void Destroy();
    }
}
