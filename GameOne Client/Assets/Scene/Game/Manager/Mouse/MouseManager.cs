using UnityEngine;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    class MouseManager : IMouseManager
    {
        public IObj2D _point = new Point(new Vector2());
        public MouseButtonState _state = new MouseButtonState();
        private IObj2D _focusObj;

        public Vector2 Pos
        {
            get
            {
                return _point.Pos;
            }
        }

        public IMouseButtonState State
        {
            get
            {
                return _state;
            }
           
        }
        public IObj2D FocusObj
        {
            get
            {
                if (_focusObj == null)
                    return _point;
                return _focusObj;
            }
            set
            {
                _focusObj = value;
            }
        }

        public void Update()
        {
            _point.Pos = GetMousePos();
            _state.Set(Input.GetMouseButton(0));
        }

        private Vector2 GetMousePos()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
