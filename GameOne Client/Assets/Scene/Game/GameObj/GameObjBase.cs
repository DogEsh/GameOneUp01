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
        public ushort ID
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
