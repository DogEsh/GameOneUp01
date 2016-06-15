using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    public class SimplusGraphics : MonoBehaviour, ISimplusGraphics
    {
        private ISimplusAnimationState _animationState;
        private ITransformCoordinate _transform;
        private ISimplusInfo _info;
        private GameObject _mySimplus;
        private Sprite _simplusSprite;
        private RegisterSimplusAnimationState _registerAnimation;
        public void Initialize(ISimplusInfo info, ITransformCoordinate tran)
        {
            _transform = tran;
            _info = info;
        }
        private void Start()
        {
            _mySimplus = gameObject.transform.parent.gameObject;
            _registerAnimation = new RegisterSimplusAnimationState();
            _animationState = new SimplusAnimationState();

            //Texture2D texture = Resources.Load<Texture2D>("Menu/Textures/GameBackground");
            //Rect rect = new Rect(0, 0, texture.width, texture.height);


            Texture2D texture = Resources.Load<Texture2D>("Game/Textures/TextureSimpluses");
            Rect rect = new Rect(texture.width / 4 * (_info.Party.ID % 4), 0, texture.width / 4, texture.height);
            Vector2 center = new Vector2(0.5f, 0.5f);


            _simplusSprite = Sprite.Create(texture, rect, center);
            gameObject.GetComponent<SpriteRenderer>().sprite = _simplusSprite;
        }
        private void Update()
        {
            UpdateScale();
            UpdateAnimation();
        }
        private void UpdateScale()
        {
            Sprite sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            float pixelsPerUnit = sprite.pixelsPerUnit;
            float height = sprite.rect.height;
            float width = sprite.rect.width;
            

            Vector3 scale = _mySimplus.transform.localScale;
            scale.x = _transform.Size * 2 * _info.Obj2D.Radius * pixelsPerUnit / width;
            scale.y = _transform.Size * 2 * _info.Obj2D.Radius * pixelsPerUnit / height;
            _mySimplus.transform.localScale = scale;

            Vector3 p = _transform.TransformPos(_info.Obj2D.Pos);
            p.z = _mySimplus.transform.position.z;
            _mySimplus.transform.position = p;
        }
        private void UpdateAnimation()
        {
            if (!_animationState.IsChanged) return;
            string name = _registerAnimation.GetName(_animationState.GetState());
            gameObject.GetComponent<Animator>().SetTrigger(name);
        }
        public ISimplusAnimationState GetAnimation()
        {
            return _animationState;
        }
    }
}
