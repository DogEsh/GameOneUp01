using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    public enum SimplusActionStateOld
    {
        Passive,
        Focused,
        Pressed
    }
    public class SimplusActionStaterOld : ISimplusActionStaterOld
    {
        private bool _isFocused;
        private bool _isPressed;


        public SimplusActionStateOld GetState()
        {
            if (_isPressed)
                return SimplusActionStateOld.Pressed;
            if (_isFocused)
                return SimplusActionStateOld.Focused;

            return SimplusActionStateOld.Passive;
        }

        public void SetFocused(bool isFocused)
        {
            _isFocused = isFocused;
        }

        public void SetPressed(bool isPressed)
        {
            _isPressed = isPressed;
        }
    }

    
}
