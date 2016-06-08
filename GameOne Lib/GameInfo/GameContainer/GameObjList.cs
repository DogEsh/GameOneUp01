using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.GameOne.GameInfo
{
    public class GameObjList<T> : IGameObjContainer<T>
        where T : IGameID
    {
        private List<T> _container;

        public GameObjList()
        {
            _container = new List<T>();
        }

        public int Count
        {
            get
            {
                return _container.Count;
            }
        }

        public T GetObj(ushort ID)
        {
            foreach (T obj in _container)
            {
                
                if (obj.ID == ID)
                {
                    return obj;
                }
            }
            return default(T);
        }

        public void SetObj(T gameObj)
        {
            _container.Add(gameObj);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _container.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
