using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    public class SimplusOld : MonoBehaviour
    {
        public SimplusWrapperOld _wrapper;

        private SimplusInfo _info;

        private ArrayList _links;

        public GameMapOld _map;



        //rm
        private const string _pathLink = "Game/SimplusLinkPrefab";
        private GameObject _linkPrefab;

        //rm
        private SimplusLinkOld _link;

        public SimplusInfo Info
        {
            get
            {
                return _info;
            }
        }

        //public SimplusInfo Info { get; set; }

        private void Start()
        {
            _linkPrefab = Resources.Load<GameObject>(_pathLink);
        }

        public void InitInfo(SimplusInfo info)
        {
            gameObject.transform.position = info.Obj2D.GetPos();

            SetInfo(info);
        }

        public void SetInfo(SimplusInfo info)
        {
            foreach (SimplusLinkInfo inf in info.Links)
            {
                //if (inf.Equals(_links)
                //    continue;
                HandleLink(inf);
            }
            //go through link list (info)
            //if there are not the same
            //update links (create if needed)
            //update info

            SetWrapper(info);

            _info.SetInfo(info);
        }

        public void SetWrapper(SimplusInfo info)
        {
            
        }

        public void HandleLink(SimplusLinkInfo info)
        {
            if (null == _links[info.ID])
            {
                CreateLink(info);
            }
            if (null != _links[info.ID] && null != info)
            {
                DestroyLink(info);
            }

            UpdateLink(info);
        }

        public void UpdateLink(SimplusLinkInfo info)
        {
            (_links[info.ID] as SimplusLinkOld).Info = info;
            
        }

        public void CreateLink(SimplusLinkInfo info)
        {
            SimplusOld dest = _map.GetSimplus(info.ID);
            _links.Add(CreateLink(dest));
        }

        public void DestroyLink(SimplusLinkInfo info)
        {
            (_links[info.ID] as SimplusLinkOld).Destroy();
            _links.RemoveAt(info.ID);
        }

        //rm
        public SimplusLinkOld CreateLink(SimplusOld destination)
        {
            
            //_link = new SimplusLink(this, destination);
            GameObject linkObj = Instantiate(_linkPrefab);
            _link = linkObj.GetComponent<SimplusLinkOld>();
            _link.SetSimplusLinkData(this, destination);
            return _link;
        }

        //public bool IsFocused(Vector2 focusPos)
        //{
        //    return _wrapper.IsFocused(focusPos);
        //}
    }
}
