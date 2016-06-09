using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    class SimplusGraghics
    {
        private ISimplusInfo _info;
        private GameObject _mySimplus;
        private Sprite _simplusSprite;
        public SimplusGraghics(GameObject mySimplus, ISimplusInfo info)
        {
            _mySimplus = mySimplus;
            _info = info;
            _mySimplus.AddComponent<SpriteRenderer>();
            _simplusSprite = Resources.Load("Game/Textures/TextureSimpluses_copy", typeof(Sprite)) as Sprite;
            _mySimplus.GetComponent<SpriteRenderer>().sprite = _simplusSprite;
        }

        public void UpdateGraghics()
        {
            Vector3 _position = new Vector3(_info.Obj2D.Pos.x, _info.Obj2D.Pos.y,  0f);
            
            _mySimplus.transform.position = _position;
            
            _mySimplus.SetActive(true);
        }

        public void SetGraghicsActive(bool activity)
        {
            _mySimplus.SetActive(activity);
        }
    }
}
