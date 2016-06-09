using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.GameOne.GameInfo
{
    public class MapInfo : IMapInfo
    {
        private ITransformCoordinate _coordinate;

        private IGameObjContainer<ISimplusInfo> _containerSimplus;

        public ITransformCoordinate Coordinate
        {
            get
            {
                return _coordinate;
            }
        }

        public MapInfo(float width, float height)
        {
            _coordinate = new TransformCoordinateMap(width, height);
            _containerSimplus = new GameObjList<ISimplusInfo>();
        }
        public MapInfo(float width, float height, IGameObjContainer<ISimplusInfo> containerSimplus)
        {
            _coordinate = new TransformCoordinateMap(width, height);
            _containerSimplus = containerSimplus;
        }
        public IGameObjContainer<ISimplusInfo> GetContainerSimplus()
        {
            return _containerSimplus;
        }
    }
}
