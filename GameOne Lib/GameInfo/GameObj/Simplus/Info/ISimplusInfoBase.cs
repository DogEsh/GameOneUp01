using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.GameOne.GameInfo
{
    public interface ISimplusInfoBase : IGameObjID
    {
        IParty Party { get; }
        ISimplusHP HP { get; }
        Circle Obj2D { get; }
        ILinkInfoContainer Links { get; }
    }
}
