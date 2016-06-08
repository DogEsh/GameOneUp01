using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    public class LinkActionDrawerOld : MonoBehaviour
    {
        public enum LinkState
        {
            Link,
            Shears
        }

        private GameObject _instance;
        private SpriteRenderer _sprRenderer;
        private float _pixelsPerUnit;
        private float _width;

        private Sprite LinkSprite;
        private Sprite ShearsSprite;

        public void Start()
        {
            // Customly set the pivot
            LinkSprite = Resources.Load("GameOld/Textures/Arrow", typeof(Sprite)) as Sprite;
            ShearsSprite = Resources.Load("ShearsSprite", typeof(Sprite)) as Sprite;

            _instance = new GameObject("LinkSpriteInstance");
            _instance.AddComponent<SpriteRenderer>();
            _sprRenderer = _instance.GetComponent<SpriteRenderer>();

            Visible(true);
        }
        
        private void SetSpite(LinkState state)
        {
            if (state == LinkState.Link)
                _sprRenderer.sprite = LinkSprite;
            if (state == LinkState.Shears)
                _sprRenderer.sprite = ShearsSprite;

            _pixelsPerUnit = _sprRenderer.sprite.pixelsPerUnit;
            _width = _sprRenderer.sprite.rect.width;
        }

        public void UpdateInfo(DragInfoOld drag, LinkState state)
        {
            SetSpite(state);
            UpdateSpriteTransform(drag.GetPosSource(), drag.GetPosDestination());
        }
    
        public void Visible(bool isVisible)
        {
            _instance.SetActive(isVisible);
        }

        void UpdateSpriteTransform(Vector2 SourcePos, Vector2 DestinationPos)
        {
            var _position = new Vector3(SourcePos.x, SourcePos.y, 0f);
            var _rotation = Quaternion.Euler(0f, 0f, CalculateAngle(SourcePos, DestinationPos));

            float scaleNumber = CalculateScale(SourcePos, DestinationPos, _pixelsPerUnit, _width);
            var _scale = new Vector3(scaleNumber, scaleNumber, 0);

            _instance.transform.position = _position;
            _instance.transform.rotation = _rotation;
            _instance.transform.localScale = _scale;
        }

        float CalculateAngle(Vector2 start, Vector2 end)
        {
            Vector2 difference = end - start;
            difference.Normalize();
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            return rotZ;
        }

        float CalculateScale(Vector2 start, Vector2 end, float pixPerUnit, float pixWidth)
        {
            var difference = start - end;
            float vectorLength = difference.magnitude;

            float scaleNumber = vectorLength * _pixelsPerUnit / _width;

            return scaleNumber;
        }

    }
}
