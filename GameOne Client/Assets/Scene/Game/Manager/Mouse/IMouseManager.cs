using UnityEngine;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    interface IMouseManager
    {
        Vector2 Pos { get; }
        IMouseButtonState State { get; }
        ISimplus FocusSimplus { get; }
        void Update();
    }
}
