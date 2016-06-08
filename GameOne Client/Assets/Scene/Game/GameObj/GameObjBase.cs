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
        public abstract ushort ID { get; }

        public abstract void Destroy();

        public void RequestDestroy()
        {
            throw new NotImplementedException();
        }
    }
}
