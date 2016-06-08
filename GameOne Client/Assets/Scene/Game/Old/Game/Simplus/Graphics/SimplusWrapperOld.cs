using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene 
{
    public class SimplusWrapperOld : MonoBehaviour, IObj2D, ISimplusActionStaterOld
    {
        private SimplusActionStaterOld stater = new SimplusActionStaterOld();
        private Circle _circle;
        public GameObject MyInstance;
        private SimplusAnimationManagerOld _animManager;

        public void Start()
        {
            GameObject circleObject = gameObject;
            Vector2 pos = circleObject.transform.position;
            Sprite spr = circleObject.GetComponent<SpriteRenderer>().sprite;
            float radius = (spr.texture.width / 2) / spr.pixelsPerUnit * 0.8f;
            _circle = new Circle(pos, radius);
            _animManager = new SimplusAnimationManagerOld(MyInstance.GetComponent<Animator>());
        }

        public Vector2 GetPos()
        {
            return ((IObj2D)_circle).GetPos();
        }

        public Vector2 GetPosSurface(Vector2 destination)
        {
            return ((IObj2D)_circle).GetPosSurface(destination);
        }

        public bool IsFocused(Vector2 pos)
        {
            return ((IObj2D)_circle).IsFocused(pos);
        }

        public void SetFocused(bool isFocused)
        {
            ((ISimplusActionStaterOld)stater).SetFocused(isFocused);
            _animManager.SetActionState(stater.GetState());
        }

        public void SetPressed(bool isPressed)
        {
            ((ISimplusActionStaterOld)stater).SetPressed(isPressed);
            _animManager.SetActionState(stater.GetState());
        }

        //public Vector2 GetPos()
        //{
        //    V = _obj.transform.position;
        //    return _obj.transform.position;
        //}

        //public Vector2 GetPosSurface(Vector2 destination)
        //{
        //    RaycastHit2D[] hits =  Physics2D.RaycastAll(destination, GetPos(), LayerMask.NameToLayer("Simplus"));
        //    Debug.DrawLine(destination, GetPos());
        //    for (int i = 0; i < hits.Length; i++)
        //    {
        //        if (hits[i].transform.gameObject == _obj)
        //        {
        //            Debug.DrawLine(hits[i].point, _obj.transform.position, Color.green);
        //            return hits[i].point;
        //        }
        //    }
        //    return Vector2.zero;
        //}
    }
}
