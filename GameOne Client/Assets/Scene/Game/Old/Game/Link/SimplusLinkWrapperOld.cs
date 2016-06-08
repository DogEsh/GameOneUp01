using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    public class SimplusLinkWrapperOld : MonoBehaviour
    {
        public void SetSimplusLinkWrapperData(Vector2 source, Vector2 destination)
        {
            Debug.Log("SimplusLinkWrapper constructor");
            _source = source;
            _destination = destination;
            _current = destination;

        }
        public void Start()
        {
            _partusContainer = new List<GameObject>();

            Debug.Log("Simpl Link Start");
            LinkSprite = Resources.Load("LinkPart", typeof(Sprite)) as Sprite;

            _pixelsPerUnit = LinkSprite.pixelsPerUnit;
            _width = LinkSprite.rect.width;

            _instance = new GameObject("instance");
            _instance.AddComponent<SpriteRenderer>().sprite = LinkSprite;
            _instance.SetActive(false);
            InvalidateTime();
        }

        public float Speed = 1f;

        private Vector2 _source;
        private Vector2 _destination;
        private Vector2 _current;

        private List<GameObject> _partusContainer;

        private SpriteRenderer _sprRenderer;
        private float _pixelsPerUnit;
        private float _width;
        private Sprite LinkSprite;

        private SimplusLinkActionState _state;

        private GameObject _instance;

        private float _resetTime = 0f;

        //public float FlyInterval = 1f;

        private float _timeToAct = 0f;

        private float _curLinkPos;

        private float _time()
        {
            return Time.time - _resetTime;
        }

        void CalcLinkPos()
        {
            _curLinkPos = _time() / _timeToAct * Speed;
        }

        public void SetAnimationState(SimplusLinkActionState state)
        {
            _state = state;
        }

        void SetTimeData()
        {
            Debug.Log("set");
            _resetTime = Time.time;
            _timeToAct = (_destination - _source).magnitude / Speed;
        }

        void InvalidateTime()
        {
            _resetTime = 0f;
            _timeToAct = 0f;
        }

        bool IsTimeValid()
        {
            return (_resetTime != 0 && _timeToAct != 0);
        }

        public void Update()
        {
            //Debug.Log("Update");
            if (_state == SimplusLinkActionState.Transporting)
            {

            }
            
            if (_state == SimplusLinkActionState.Flying)
            {
                //Debug.Log("flying");
                if (!IsTimeValid())
                {
                    Debug.Log("!IsTimeValid");
                    SetTimeData();
                    _instance.SetActive(true);
                }
                if (_curLinkPos > 1f)
                {
                    Debug.Log("_curLinkPos > 1f");
                    _state = SimplusLinkActionState.Transporting;
                    InvalidateTime();
                }
                CalcLinkPos();
                _instance.transform.position = Vector2.Lerp(_source, _destination, _curLinkPos);
            }
        }

        private void LaunchPart()
        {
            CreatePart();
            SendPart();
        }

        private void CreatePart()
        {
            GameObject part = new GameObject("Link Part" + _partusContainer.Count.ToString());
            part.transform.position = _source;
        }

        private void SendPart()
        {

        }
    }
}
