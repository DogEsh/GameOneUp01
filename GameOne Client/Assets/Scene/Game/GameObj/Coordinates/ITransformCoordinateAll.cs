using UnityEngine;

namespace SimpleTeam.GameOne.GameInfo
{
    public interface ITransformCoordinateAll
    {
        ITransformCoordinate Map { get; }
        ITransformCoordinate Screen { get; }
    }
}
