using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    

    public class MouseButtonStateOld
    {
        HelperMouseState _state;
        public void Set(bool isPressed)
        {
            if (isPressed)
            {
                switch (_state)
                {
                    case HelperMouseState.Pressed:
                        break;
                    case HelperMouseState.Down:
                        _state = HelperMouseState.Pressed;
                        break;
                    case HelperMouseState.Nope:
                        _state = HelperMouseState.Down;
                        break;
                    case HelperMouseState.Up:
                        _state = HelperMouseState.Down;
                        break;
                }
            }
            else
            {
                switch (_state)
                {
                    case HelperMouseState.Nope:
                        break;
                    case HelperMouseState.Up:
                        _state = HelperMouseState.Nope;
                        break;
                    case HelperMouseState.Pressed:
                        _state = HelperMouseState.Up;
                        break;
                    case HelperMouseState.Down:
                        _state = HelperMouseState.Up;
                        break;
                }
            }
        }
        public HelperMouseState Get()
        {
            return _state;
        }
    }

    public class MouseManagerOld
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
