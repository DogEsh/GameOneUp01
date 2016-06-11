using UnityEngine;

namespace SimpleTeam.GameOne.GameInfo
{
    public interface IObj2D
    {
        Vector2 Pos { get; set; }

        Vector2 GetPosSurface(Vector2 destination);
        Vector2 GetPosSurface(Vector2 destination, ITransformCoordinate tran);
        bool IsFocused(Vector2 pos);
        bool IsFocused(Vector2 pos, ITransformCoordinate tran);
    }
}
