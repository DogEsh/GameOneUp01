using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.GameOne.GameInfo
{
    using GameID = UInt16;
    public interface IGameObjContainer<T> : IEnumerable<T>
        where T : IGameID
    {
        T GetObj(GameID ID);

        void SetObj(T gameObj);
        int Count { get; }
    }
}
