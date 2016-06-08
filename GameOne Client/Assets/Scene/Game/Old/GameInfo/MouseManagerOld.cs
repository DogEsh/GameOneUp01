using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    public enum MouseState
    {
        Nope,
        Down,
        Pressed,
        Up
    }

    public class MouseButtonStateOld
    {
        MouseState _state;
        public void Set(bool isPressed)
        {
            if (isPressed)
            {
                switch (_state)
                {
                    case MouseState.Pressed:
                        break;
                    case MouseState.Down:
                        _state = MouseState.Pressed;
                        break;
                    case MouseState.Nope:
                        _state = MouseState.Down;
                        break;
                    case MouseState.Up:
                        _state = MouseState.Down;
                        break;
                }
            }
            else
            {
                switch (_state)
                {
                    case MouseState.Nope:
                        break;
                    case MouseState.Up:
                        _state = MouseState.Nope;
                        break;
                    case MouseState.Pressed:
                        _state = MouseState.Up;
                        break;
                    case MouseState.Down:
                        _state = MouseState.Up;
                        break;
                }
            }
        }
        public MouseState Get()
        {
            return _state;
        }
    }

    public class MouseManager
    {
        //private GameObject _mouseObj;
        //public GameObject _simplusInteract;

        public Vector2 Pos;
        public MouseButtonStateOld State = new MouseButtonStateOld();

        //public void OnTriggerEnter2D(Collider2D other)
        //{
        //    Debug.Log("enter");
        //    if (other.gameObject.layer == LayerMask.NameToLayer("Simplus"))
        //        _simplusInteract = other.gameObject;
        //    else
        //        _simplusInteract = null;
        //}

        //public void Start()
        //{
        //    _mouseObj = new GameObject("Mouse");
        //    _mouseObj.AddComponent<BoxCollider2D>();
        //    _mouseObj.GetComponent<BoxCollider2D>().size = new Vector2(0.1f, 0.1f);
        //    _mouseObj.GetComponent<BoxCollider2D>().isTrigger = true;
        //    _mouseObj.transform.position = new Vector3(0f, 0f, 0f);
        //}

        public void Update()
        {
            Pos = GetMousePos();
            State.Set(Input.GetMouseButton(0));

            //_mouseObj.transform.position = Pos;
        }

        private Vector2 GetMousePos()
        {
            //Vector2 pos;
            //pos = Input.mousePosition;
            //pos.y = Screen.height - pos.y;
            //return pos;
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        //public GameObject MouseOver()
        //{
        //    return _simplusInteract;
        //}
    }
}
