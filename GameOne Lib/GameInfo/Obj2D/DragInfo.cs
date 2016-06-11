using UnityEngine;

namespace SimpleTeam.GameOne.GameInfo
{
    public class DragInfo
    {
        private IObj2D _source;
        private IObj2D _destination;
        private ITransformCoordinate _transform;
        public DragInfo()
        {
            _transform = new TransformCoordinateMap(1, 1);
        }
        public DragInfo(ITransformCoordinate tran)
        {
            _transform = tran;
        }
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
            return _source.GetPosSurface(_transform.TransformPos(_destination.Pos), _transform);
        }

        public Vector2 GetPosDestination()
        {
            if (_source == null || _destination == null)
            {
                return new Vector2();
            }
            return _destination.GetPosSurface(_transform.TransformPos(_source.Pos), _transform);
        }
    }
}
