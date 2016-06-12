using UnityEngine;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    interface IMouseManager
    {
        Vector2 Pos { get; }
        IMouseButtonState State { get; }
        GameObject FocusSimplus { get; }
        void Update();
    }
}
