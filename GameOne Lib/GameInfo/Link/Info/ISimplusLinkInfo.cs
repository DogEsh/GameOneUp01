using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.GameOne.GameInfo
{
    public interface ISimplusLinkInfo : IGameID
    {
        SimplusInfo Source { get; set; }
        SimplusInfo Destination { get; set; }
        IObj2D Current { get; set; }
        IObj2D Lost { get; set; }
        SimplusLinkActionState State { get; set; }
    }
}
