using UnityEngine;
using SimpleTeam.GameOne.GameInfo;
namespace SimpleTeam.GameOne.Scene
{
    public interface ITransformCoordinateAll
    {
        ITransformCoordinate Map { get; }
        ITransformCoordinate Screen { get; }
    }
}
