using UnityEngine;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    class MouseManager : IMouseManager
    {
        public Vector2 _pos;
        public MouseButtonState _state = new MouseButtonState();
        private ISimplus _focusSimplus;

        public Vector2 Pos
        {
            get
            {
                return _pos;
            }
        }

        public IMouseButtonState State
        {
            get
            {
                return _state;
            }
           
        }
        public ISimplus FocusSimplus
        {
            get
            {
                return _focusSimplus;
            }
            set
            {
                _focusSimplus = value;
            }
        }

        public void Update()
        {
            _pos = GetMousePos();
            _state.Set(Input.GetMouseButton(0));
        }

        private Vector2 GetMousePos()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
