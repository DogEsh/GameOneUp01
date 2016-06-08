using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    public class SimplusAnimationManagerOld
    {
        public SimplusAnimationManagerOld(Animator animator)
        {
            _animator = animator;
        }

        private Animator _animator;

        public void SetActionState(SimplusActionStateOld state)
        {
            if (SimplusActionStateOld.Focused == state)
                StartAnimation("Focused");
            if (SimplusActionStateOld.Passive == state)
                StartAnimation("Passived");
            if (SimplusActionStateOld.Pressed== state)
                StartAnimation("Pressed");
        }

        private void StartAnimation(string name)
        {
            _animator.SetTrigger(name);
        }
    }
}
