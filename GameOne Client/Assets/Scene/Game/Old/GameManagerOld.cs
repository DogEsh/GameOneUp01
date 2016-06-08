using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
using SimpleTeam.GameOne.Message;
using SimpleTeam.GameOne.GameInfo;


namespace SimpleTeam.GameOne.Scene
{
    using GameID = UInt16;
    class GameManagerOld : MonoBehaviour
    {
        private MouseManagerOld _mouse = new MouseManagerOld();
        public LinkManagerOld _linkManager;
        public GameMapOld _map;

        public void UpdateLink()
        {
            SimplusOld simplus = _map.GetFocusedSimplus(_mouse.Pos);
 
            _linkManager.UpdateDraw(simplus, _mouse);
        }



        public void Update()
        {
            _mouse.Update();
            UpdateLink();
        }

        public void SetMap(MessageDataGameMap message)
        {
            ArrayList simplusInfo = new ArrayList();

            SimplusInfo info;
            {
                GameID id = 124;
                Circle circle = new Circle(Vector2.zero, 50);
                ISimplusHP hp = new SimplusHP(30);
                IParty party = new Party(0);
                ILinkInfoContainer links = new LinkInfoList();
                info = new SimplusInfo(id, circle, hp, party, links);
            }
        }
    }
}
