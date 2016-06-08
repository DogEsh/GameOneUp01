using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

namespace SimpleTeam.GameOne.GameInfo
{
    using GameID = UInt16;
    public class LinkInfoList : ILinkInfoContainer
    {

        private GameObjList<ISimplusLinkInfo> _container;
        private int _maxCount;
        public LinkInfoList()
        {
            _container = new GameObjList<ISimplusLinkInfo>();
            _maxCount = 3;
        }

        public int MaxCount
        {
            get
            {
                return _maxCount;
            }
        }

        public int Count
        {
            get
            {
                return _container.Count;
            }
        }

        public ISimplusLinkInfo GetObj(GameID ID)
        {
            return _container.GetObj(ID);
        }

        public void SetObj(ISimplusLinkInfo gameObj)
        {
            if (_container.Count < this.MaxCount)
            {
                _container.SetObj(gameObj);
            }
        }

        public IEnumerator<ISimplusLinkInfo> GetEnumerator()
        {
            return _container.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _container.GetEnumerator();
        }
    }
}
