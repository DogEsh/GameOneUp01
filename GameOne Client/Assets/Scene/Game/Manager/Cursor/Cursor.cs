using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    class Cursor : MonoBehaviour, ICursor
    {
        public GameObject MyInstance;
        IObj2D _source;
        IObj2D _destination;

        public IObj2D Source
        {
            get
            {
                return _source;
            }

            set
            {
                _source = value;
            }
        }

        public IObj2D Destination
        {
            get
            {
                return _destination;
            }

            set
            {
                _destination = value;
            }
        }

        private void Start()
        {
            MyInstance.
        }


        public void SetMouse(IMouseManager mouse)
        {
            if (HelperMouseState.Down == mouse.State.Get())
            {
                _source = mouse.FocusObj;
                _destination = mouse.FocusObj;
                MyInstance.SetActive(true);
            }
            if (HelperMouseState.Pressed == mouse.State.Get())
            {
                _destination = mouse.FocusObj;
            }
            if (HelperMouseState.Up == mouse.State.Get())
            {
                MyInstance.SetActive(false);
            }
        }
    }
}
