using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.GameOne.GameInfo
{
    interface IConcurrentInfo<T>
    {
        void SetInfo(T info, HelperStateInfo state);
        KeyValuePair<HelperStateInfo, T> GetInfo(bool flagReset = false);
        HelperStateInfo GetState();
    }
}
