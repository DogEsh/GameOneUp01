using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    public class SimplusGraghics : MonoBehaviour
    {
        private ITransformCoordinate _transform;
        private ISimplusInfo _info;
        private GameObject _mySimplus;
        private Sprite _simplusSprite;
        public void Initialize(GameObject mySimplus, ISimplusInfo info, ITransformCoordinate tran)
        {
            _transform = tran;
            _mySimplus = mySimplus;
            _mySimplus.AddComponent<SpriteRenderer>();

            //Texture2D texture = Resources.Load<Texture2D>("Menu/Textures/GameBackground");
            //Rect rect = new Rect(0, 0, texture.width, texture.height);


            Texture2D texture = Resources.Load<Texture2D>("Game/Textures/TextureSimpluses");
            Rect rect = new Rect(texture.width / 4 * (info.ID % 4), 0, texture.width / 4, texture.height);
            Vector2 center = new Vector2(0.5f, 0.5f);
            

            _simplusSprite = Sprite.Create(texture, rect, center);
            //_mySimplus.GetComponent<SpriteRenderer>().sprite = _simplusSprite;
            _info = info;
        }

        private void Update()
        {
            float pixelsPerUnit = gameObject.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
            float width = gameObject.GetComponent<SpriteRenderer>().sprite.rect.width;
            float height = gameObject.GetComponent<SpriteRenderer>().sprite.rect.height;

            Vector3 scale = _mySimplus.transform.localScale;
            scale.x = _transform.Size * 2 * _info.Obj2D.Radius * pixelsPerUnit / width;
            scale.y = _transform.Size * 2 * _info.Obj2D.Radius * pixelsPerUnit / height;
            _mySimplus.transform.localScale = scale;

            Vector3 p = _transform.TransformPos(_info.Obj2D.Pos);
            p.z = _mySimplus.transform.position.z;
            _mySimplus.transform.position = p;
            
        }
    }
}
