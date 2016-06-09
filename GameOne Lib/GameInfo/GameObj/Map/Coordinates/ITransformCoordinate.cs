using UnityEngine;

namespace SimpleTeam.GameOne.GameInfo
{
    public interface ITransformCoordinate
    {
        Vector2 TransformPos(Vector2 pos);
        Vector2 UntransformPos(Vector2 pos);
        float Size { get; }

    }
}
