using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.GameOne.Scene
{
    public enum HelperSimplusAnimationState
    {
        Idle,
        Focused,
        Pressed
    }
    public interface ISimplusAnimationState
    {
        void SetFocused(bool isFocused);
        void SetPressed(bool isPressed);
        HelperSimplusAnimationState GetState(bool flagReset = true);
        bool IsChanged { get; }
    }
}
