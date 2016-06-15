using System;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    class SimplusAnimationManager : ISimplusAnimationManager
    {
        private ISimplusGraphics _focused;
        private ISimplusGraphics _pressed;

        public void SetMouse(IMouseManager mouse)
        {
            Simplus s = mouse.FocusSimplus;
            ISimplusGraphics graphics;
            if (s == null) graphics = null;
            else
            {
                graphics = s.GetComponentInChildren<ISimplusGraphics>();
            }

            Refocus(graphics);

            Repress(graphics, mouse.State.Get());
        }
        private void Refocus(ISimplusGraphics focus)
        {
            if (focus != _focused)
            {
                if (_focused != null)
                {
                    _focused.GetAnimation().SetFocused(false);
                }
                if (focus != null)
                {
                    focus.GetAnimation().SetFocused(true);
                }
                _focused = focus;
            }
        }
        private void Repress(ISimplusGraphics focus, HelperMouseState state)
        {
            if (state == HelperMouseState.Down)
            {
                if (_pressed != null)
                {
                    _pressed.GetAnimation().SetPressed(false);
                }
                if (focus != null)
                {
                    focus.GetAnimation().SetPressed(true);
                }
                _pressed = focus;
            }
            if (state == HelperMouseState.Up)
            {
                if (_pressed != null)
                {
                    _pressed.GetAnimation().SetPressed(false);
                    _pressed = null;
                }
            }
        }

    }
}
