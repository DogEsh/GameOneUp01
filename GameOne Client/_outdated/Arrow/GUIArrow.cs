//using System;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;
//using UnityEngine.UI;

//namespace SimpleTeam.Sce
//{
//    public class GUIArrow : MonoBehaviour
//    {
//        public GameObject MyObj;
//        public Image MyImage;
//        private Simplus _source;
//        private float _angle;
//        private Vector2 _scale;
//        void Start()
//        {
//            _scale = new Vector2(1f, 1f);
//            MyImage.sprite = Resources.Load<Sprite>("Arrow");
            
//        }

//        public void SetActive(bool value)
//        {
//            MyObj.SetActive(value);
//        }
//        public void SetSource(Simplus simplus)
//        {
//            if (simplus != null)
//            {
//                _source = simplus;

//                Vector2 v = new Vector2();
//                v.x = 1;
//                v.y = 0;
//                v *= 50;
                
//                Vector3 axis = new Vector3(0f, 0f, 1f);
//                Vector2 point =  _source.Pos;
//                point.y = Screen.height - point.y;
//                MyObj.transform.Rotate(MyObj.transform.eulerAngles * (-1));
//                MyObj.transform.position = point + v;
//                MyObj.transform.RotateAround(point, axis, _angle);
//                MyObj.transform.localScale = _scale;
//            }
//        }
//        public void Turn()
//        {
//            if (_source != null)
//            {
//                Vector3 angle = new Vector3(0f, 0f, 1f);
//                Vector3 point = _source.Pos;
//                MyObj.transform.RotateAround(point, angle, 1);
//            }
                
//        }
//        public void SetDestination(Vector2 mousePos)
//        {
//            if (_source != null)
//            {
//                Vector2 nor = new Vector2();
//                nor.x = 1;
//                nor.y = 0;
//                Vector2 vec = mousePos - _source.Pos;
//                _angle = Vector2.Angle(nor, vec);
//                Vector3 cross = Vector3.Cross(nor, vec);
//                if (cross.z > 0)
//                {
//                    _angle = 360 - _angle;
//                }
//                float length = vec.magnitude - 50;
//                _scale.x = length / 110;
//            }
             
//        }
//    }
//}
