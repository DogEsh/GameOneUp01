using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.GameOne.Scene
{
    class RegisterSimplusAnimationState
    {
        private Dictionary<HelperSimplusAnimationState, string> _dictionary;
        public RegisterSimplusAnimationState()
        {
            _dictionary = new Dictionary<HelperSimplusAnimationState, string>();
            _dictionary.Add(HelperSimplusAnimationState.Idle, "Idle");
            _dictionary.Add(HelperSimplusAnimationState.Focused, "Focused");
            _dictionary.Add(HelperSimplusAnimationState.Pressed, "Pressed");
        }
        public string GetName(HelperSimplusAnimationState state)
        {
            return _dictionary[state];
        }
    }
}
