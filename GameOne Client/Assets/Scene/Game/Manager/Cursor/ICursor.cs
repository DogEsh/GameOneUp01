using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    interface ICursor
    {
        Vector2 GetSource();
        Vector2 GetDestination();
        void SetMouse(IMouseManager mouse);
        void Initialize(ITransformCoordinate tran);
    }
}
