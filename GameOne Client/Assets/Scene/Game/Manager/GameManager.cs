using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    class GameManager : MonoBehaviour
    {
        Cursor _cursor;
        MouseManager _mouse;
        IGameMap _map;

        private void Start()
        {
            _mouse = new MouseManager();
            CreateCursor();
        }
        private void CreateCursor()
        {
            const string path= "Game/CursorPrefab";
            GameObject prefab = Resources.Load<GameObject>(path);
            GameObject inst = Instantiate(prefab);
            _cursor = inst.GetComponent<Cursor>();
        }
        public void SetMap(IGameMap map)
        {
            _map = map;
        }
        private void Update()
        {
            _mouse.Update();
            _mouse.FocusObj = GetFocusObj2D();
            _cursor.SetMouse(_mouse);

        }
        private IObj2D GetFocusObj2D()
        {
            ISimplus s = _map.GetFocusedSimplus(_mouse.Pos);
            if (s == null) return null;
            return s.Obj2D;
        }
    }
}
