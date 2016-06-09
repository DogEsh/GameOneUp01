using SimpleTeam.Command.Scenario;
using UnityEngine;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    class GameManager : MonoBehaviour
    {
        Cursor _cursor;
        MouseManager _mouse;
        
        LinkManager _linkManager;

        IGameMap _map;
        IScenario _scenario;

        private void Start()
        {
            _mouse = new MouseManager();
            _linkManager = new LinkManager(_scenario);
            CreateCursor();
        }
        private void CreateCursor()
        {
            const string path = "Game/CursorPrefab";
            GameObject prefab = Resources.Load<GameObject>(path);
            GameObject inst = Instantiate(prefab);
            _cursor = inst.GetComponent<Cursor>();
        }
        public void Initialize(IGameMap map, IScenario scenario)
        {
            _map = map;
            _scenario = scenario;
        }
        private void Update()
        {
            _mouse.Update();
            _mouse.FocusSimplus = _map.GetFocusedSimplus(_mouse.Pos);
            _cursor.SetMouse(_mouse);

        }
    }
}
