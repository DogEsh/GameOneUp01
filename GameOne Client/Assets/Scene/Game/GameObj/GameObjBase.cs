using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    abstract class GameObjBase : MonoBehaviour, IGameObj
    {
        public GameObject MyInstance;
        private bool _isToDestroy = false;
        protected bool IsToDestroy
        {
            get
            {
                return _isToDestroy;
            }
        }
        public abstract ushort ID { get; }

        public abstract void Destroy();

        protected bool CheckDestroy()
        {
            if (IsToDestroy)
            {
                Destroy();
                return true;
            }
            return false;
        }

        public void RequestDestroy()
        {
            _isToDestroy = true;
        }
    }
}
