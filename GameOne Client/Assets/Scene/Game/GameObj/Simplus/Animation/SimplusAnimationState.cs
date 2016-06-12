using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.GameOne.Scene
{
    public class SimplusAnimationState : ISimplusAnimationState
    {
        private bool _isFocused;
        private bool _isPressed;

        private bool _isChanged;
        private HelperSimplusAnimationState _state;

        public HelperSimplusAnimationState GetState(bool flagReset = true)
        {
            _isChanged = _isChanged & !flagReset;
            return _state;
        }
        public bool IsChanged
        {
            get
            {
                return _isChanged;
            }
        }
        public void SetFocused(bool isFocused)
        {
            _isFocused = isFocused;
            CheckChange();
        }

        public void SetPressed(bool isPressed)
        {
            _isPressed = isPressed;
            CheckChange();
        }
        private void CheckChange()
        {
            HelperSimplusAnimationState state;
            state = CalcState();

            _isChanged = _isChanged || (state != _state);
            _state = state;
        }
        private HelperSimplusAnimationState CalcState()
        {
            if (_isPressed)
                return HelperSimplusAnimationState.Pressed;
            if (_isFocused)
                return HelperSimplusAnimationState.Focused;

            return HelperSimplusAnimationState.Idle;
        }
    }
}
