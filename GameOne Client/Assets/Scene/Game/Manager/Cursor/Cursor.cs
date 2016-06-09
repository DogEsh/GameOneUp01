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
        DragInfo _dragInfo = new DragInfo();
        private Sprite _linkSprite;
        private float _pixelsPerUnit;
        private float _width;
        public Vector2 GetSource()
        {
            return _dragInfo.GetPosSource();
        }
        public Vector2 GetDestination()
        {
            return _dragInfo.GetPosDestination();
        }
        private void Start()
        {
            MyInstance.AddComponent<SpriteRenderer>();
            _linkSprite = Resources.Load("GameOld/Textures/Arrow", typeof(Sprite)) as Sprite;
            MyInstance.GetComponent<SpriteRenderer>().sprite = _linkSprite;
            _pixelsPerUnit = MyInstance.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
            _width = MyInstance.GetComponent<SpriteRenderer>().sprite.rect.width;
            MyInstance.SetActive(true);
        }

        private void Update()
        {
            UpdateInstance();
        }

        //****************
        void UpdateSpriteTransform(Vector2 SourcePos, Vector2 DestinationPos)
        {
            _pixelsPerUnit = MyInstance.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
            _width = MyInstance.GetComponent<SpriteRenderer>().sprite.rect.width;
            var _position = new Vector3(SourcePos.x, SourcePos.y, 0f);
            var _rotation = Quaternion.Euler(0f, 0f, CalculateAngle(SourcePos, DestinationPos));

            float scaleNumber = CalculateScale(SourcePos, DestinationPos);
            var _scale = new Vector3(scaleNumber, 2f, 0);

            MyInstance.transform.position = _position;
            MyInstance.transform.rotation = _rotation;
            MyInstance.transform.localScale = _scale;
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

        private void UpdateInstance()
        {
            UpdateSpriteTransform(_dragInfo.GetPosSource(), _dragInfo.GetPosDestination());
        }

        public void SetMouse(IMouseManager mouse)
        {
            ISimplus s = mouse.FocusSimplus;
            IObj2D obj;
            if (s == null) obj = new Point(mouse.Pos);
            else obj = s.Obj2D;


            if (HelperMouseState.Down == mouse.State.Get())
            {
                _dragInfo.SetSource(obj);
                _dragInfo.SetDestination(obj);
                UpdateInstance();
                MyInstance.SetActive(true);
               

            }
            if (HelperMouseState.Pressed == mouse.State.Get())
            {
                _dragInfo.SetDestination(obj);
            }
            if (HelperMouseState.Up == mouse.State.Get())
            {
                MyInstance.SetActive(false);
            }
        }
    }
}
