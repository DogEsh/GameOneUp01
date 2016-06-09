using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    public class SimplusGraghics
    {
        private ISimplusInfo _info;
        private GameObject _mySimplus;
        private Sprite _simplusSprite;
        public SimplusGraghics(GameObject mySimplus, ISimplusInfo info)
        {
            _mySimplus = mySimplus;
            _mySimplus.AddComponent<SpriteRenderer>();

            Texture2D texture = Resources.Load("Game/Textures/TextureSimpluses", typeof(Texture2D)) as Texture2D;
            Vector2 center = new Vector2(0.5f, 0.5f);
            Rect rect = new Rect(texture.width / 4 * (info.ID%4), 0, texture.width/4, texture.height);

            _simplusSprite = Sprite.Create(texture, rect, center);
            _mySimplus.GetComponent<SpriteRenderer>().sprite = _simplusSprite;
            _info = info;
        }

        public void UpdateGraghics()
        {
            Vector3 _position = new Vector3(_info.Obj2D.Pos.x, _info.Obj2D.Pos.y,  0f);
            Vector3 _scale = new Vector3(_info.Obj2D.Radius, _info.Obj2D.Radius, 0f);
            _mySimplus.transform.position = _position;
            _mySimplus.transform.localScale = _scale;
        }

        public void SetGraghicsActive(bool activity)
        {
            _mySimplus.SetActive(activity);
        }
    }
}
