using SimpleTeam.Command.Scenario;
using UnityEngine;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        Cursor _cursor;
        MouseManager _mouse;
        
        LinkManager _linkManager;
        ISimplusAnimationManager _animationSimplus;
        IGameMap _map;
        IScenario _scenario;
        private ITransformCoordinateScreen _transform;

        private void Start()
        {
            IMapInfo mapInfo = CreateMapInfo();
            _transform = new TransformCoordinateScreen(mapInfo.Coordinate);
            CreateMap(mapInfo);
           
            _mouse = new MouseManager();
            _linkManager = new LinkManager(_scenario);
            CreateCursor();
            _animationSimplus = new SimplusAnimationManager();
        }
        private void CreateCursor()
        {
            const string path = "Game/CursorPrefab";
            GameObject prefab = Resources.Load<GameObject>(path);
            GameObject inst = Instantiate(prefab);
            inst.transform.parent = gameObject.transform;
            _cursor = inst.GetComponent<Cursor>();
            _cursor.Initialize(_transform);
        }
        public void Initialize(IScenario scenario)
        {
            _scenario = scenario;
        }
        private void Update()
        {
            _mouse.Update();
            _mouse.FocusSimplus = _map.GetFocusedSimplus(_mouse.Pos);
            _cursor.SetMouse(_mouse);
            _transform.Update();
            _animationSimplus.SetMouse(_mouse);
        }

        public IGameMap GetMap()
        {
            return _map;
        }
        private void CreateMap(IMapInfo mapInfo)
        {
            const string path = "Game/GameMapPrefab";
            GameObject prefab = Resources.Load<GameObject>(path);
            GameObject inst = Instantiate(prefab);
            inst.transform.parent = gameObject.transform;
            _map = inst.GetComponent<GameMap>();
            _map.Initialize(_transform);
            _map.InitInfo(mapInfo);
        }
        private IMapInfo CreateMapInfo()
        {
            ISimplusInfo simplus;
            Circle circle;
            ISimplusHP simplusHp;
            IParty party;
            ILinkInfoContainer linkContainer;
            IGameObjContainer<ISimplusInfo> mySimplus;

            linkContainer = new LinkInfoList();
            party = new Party(5);
            simplusHp = new SimplusHP(10, 100, 10);
            circle = new Circle(new Vector2(0f, 0f), 0.1f);
            simplus = new SimplusInfo(1, circle, simplusHp, party, linkContainer);
            mySimplus = new GameObjList<ISimplusInfo>();
            mySimplus.SetObj(simplus);
            IMapInfo mapInfo = new MapInfo(16, 9, mySimplus);
            return mapInfo;
        }
    }
}
