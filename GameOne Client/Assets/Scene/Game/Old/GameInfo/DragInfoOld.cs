using UnityEngine;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    public class DragInfoOld
    {
        private IObj2D _source;
        private IObj2D _destination;

        public void SetSource(IObj2D source)
        {
            _source = source;
        }

        public void SetDestination(IObj2D destination)
        {
            _destination = destination;
        }

        public Vector2 GetPosSource()
        {
            if (_source == null || _destination == null)
            {
                return new Vector2();
            }
            return _source.GetPosSurface(_destination.Pos);
        }

        public Vector2 GetPosDestination()
        {
            if (_source == null || _destination == null)
            {
                return new Vector2();
            }
            return _destination.GetPosSurface(_source.Pos);
        }
    }
}
