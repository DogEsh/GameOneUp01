using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    public class LinkManagerOld : MonoBehaviour
    {
        private LinkLogicsOld _logics;
        public LinkActionDrawerOld _drawer;

        public void Start()
        {
            _logics = new LinkLogicsOld();
            //_drawer = new LinkActionDrawer();
        }

        public void Update()
        {
            MessageLinkOld m = _logics.GetMessage();
            if (m != null)
            {
                Debug.Log("Create link");
                m.Source.CreateLink(m.Destination);
            }
        }

        public void UpdateDraw(SimplusOld simplus, MouseManager mouse)
        {
            _logics.SetFocus(simplus);
            _logics.SetMouseState(mouse.State.Get());

            if (_logics.ToDraw)
            {
                DragInfoOld drag = new DragInfoOld();
                drag.SetSource(_logics.Source._wrapper);
                if (_logics.Focus != null)
                {
                    drag.SetDestination(_logics.Focus._wrapper);
                }
                else
                {
                    
                    drag.SetDestination(new Point(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
                }
                _drawer.UpdateInfo(drag, LinkActionDrawerOld.LinkState.Link);
                _drawer.Visible(true);
            }
            else
                _drawer.Visible(false);
        }
    }
}
