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
        private ITransformCoordinate _transform;
        private ISimplusInfo _info;
        private GameObject _mySimplus;
        private Sprite _simplusSprite;
        public SimplusGraghics(GameObject mySimplus, ISimplusInfo info, ITransformCoordinate tran)
        {
            _transform = tran;
            _mySimplus = mySimplus;
            _mySimplus.AddComponent<SpriteRenderer>();


            Texture2D texture = Resources.Load<Texture2D>("Game/Textures/LinkPart");
            Rect rect = new Rect(0, 0, texture.width, texture.height);

            //Texture2D texture = Resources.Load<Texture2D>("Game/Textures/TextureSimpluses");
            //Rect rect = new Rect(texture.width / 4 * (info.ID % 4), 0, texture.width / 4, texture.height);
            Vector2 center = new Vector2(0.5f, 0.5f);
            

            _simplusSprite = Sprite.Create(texture, rect, center);
            _mySimplus.GetComponent<SpriteRenderer>().sprite = _simplusSprite;
            _info = info;
        }

        public void UpdateGraghics()
        {
            Vector2 v = _mySimplus.GetComponent<SpriteRenderer>().sprite.rect.size;
            v = Camera.main.ScreenToWorldPoint(v/2);
            float f = v.magnitude;
            float pixelsPerUnit = _mySimplus.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
            float sizeUnit = Mathf.Sqrt(pixelsPerUnit);

            float scaleNumber = _transform.Size * _info.Obj2D.Radius / f;

            Vector3 _position = new Vector3(_info.Obj2D.Pos.x, _info.Obj2D.Pos.y,  0f);
            Vector3 _scale = new Vector3(scaleNumber, scaleNumber, 0f);
            _mySimplus.transform.position = _position;
            _mySimplus.transform.localScale = _scale;
        }

        public void SetGraghicsActive(bool activity)
        {
            _mySimplus.SetActive(activity);
        }
    }
}
