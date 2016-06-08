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
            MyInstance.SetActive(true);
        }

        private void Update()
        {
            UpdateInstance();

            //MyInstance.transform.localScale = new Vector2(_destination.Pos.x - _source.Pos.x, _destination.Pos.y - _source.Pos.y);
        }
        private void UpdateInstance()
        {
            MyInstance.transform.position = _dragInfo.GetPosSource();
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
