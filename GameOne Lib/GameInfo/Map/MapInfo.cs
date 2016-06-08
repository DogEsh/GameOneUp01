using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.GameOne.GameInfo
{
    public class MapInfo : IMapInfo
    {
        private IGameObjContainer<ISimplusInfo> _containerSimplus;
        public MapInfo(IGameObjContainer<ISimplusInfo> containerSimplus)
        {
            _containerSimplus = containerSimplus;
        }
        public IGameObjContainer<ISimplusInfo> GetContainerSimplus()
        {
            return _containerSimplus;
        }
    }
}
