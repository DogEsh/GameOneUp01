using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    class CursorGraphics
    {
        private GameObject _myCursor;
        private Sprite _linkSprite;
        private float _pixelsPerUnit;
        private float _width;
        
        public CursorGraphics(GameObject myInstance)
        {
            _myCursor = myInstance;
            _myCursor.AddComponent<SpriteRenderer>();
            _linkSprite = Resources.Load("Game/Textures/Arrow", typeof(Sprite)) as Sprite;
            _myCursor.GetComponent<SpriteRenderer>().sprite = _linkSprite;
            _pixelsPerUnit = _myCursor.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
            _width = _myCursor.GetComponent<SpriteRenderer>().sprite.rect.width;
        }

        //****************
        void UpdateSpriteTransform(Vector2 SourcePos, Vector2 DestinationPos)
        {
            _pixelsPerUnit = _myCursor.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
            _width = _myCursor.GetComponent<SpriteRenderer>().sprite.rect.width;
            var _position = new Vector3(SourcePos.x, SourcePos.y, 0f);
            var _rotation = Quaternion.Euler(0f, 0f, CalculateAngle(SourcePos, DestinationPos));

            float scaleNumber = CalculateScale(SourcePos, DestinationPos);
            var _scale = new Vector3(scaleNumber, 2f, 0);

            _myCursor.transform.position = _position;
            _myCursor.transform.rotation = _rotation;
            _myCursor.transform.localScale = _scale;
        }

        float CalculateScale(Vector2 start, Vector2 end)
        {
            var difference = start - end;
            float vectorLength = difference.magnitude;
            float scaleNumber = vectorLength * _pixelsPerUnit / _width;
            return scaleNumber;
        }
        float CalculateAngle(Vector2 start, Vector2 end)
        {
            Vector2 difference = end - start;
            difference.Normalize();
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            return rotZ;
        }
        //*********************
        public void UpdateGraghics(DragInfo dragInfo)
        {
            UpdateSpriteTransform(dragInfo.GetPosSource(), dragInfo.GetPosDestination());
        }

        public void SetGraghicsActive(bool activity)
        {
            _myCursor.SetActive(activity);
        }
    }
}
