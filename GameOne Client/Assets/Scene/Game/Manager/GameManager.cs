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
        GameMap _map;
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
            Simplus s = _map.GetFocusedSimplus(_mouse.Pos);
            _mouse.FocusSimplus = _map.GetFocusedSimplus(_mouse.Pos);
            _cursor.SetMouse(_mouse);
            _transform.Update();
            _animationSimplus.SetMouse(_mouse);
        }

        public GameMap GetMap()
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
            _map.GetComponentInChildren<IGameMapHandler>().SetToInitInfo(mapInfo);
        }

        private IMapInfo CreateMapInfo()
        {
            IGameObjContainer<ISimplusInfo> mySimplus;
            
            mySimplus = new GameObjList<ISimplusInfo>();
            mySimplus.SetObj(CreateSimlusInfo(0f, 0f, 0.1f, 3));
            mySimplus.SetObj(CreateSimlusInfo(0.3f, 0f, 0.1f, 1));
            IMapInfo mapInfo = new MapInfo(16, 9, mySimplus);
            return mapInfo;
        }
        private ushort id = 0;
        private ISimplusInfo CreateSimlusInfo(float posX, float posY, float radius, uint partyID)
        {
            ISimplusInfo simplus;
            Circle circle;
            ISimplusHP simplusHp;
            IParty party;
            ILinkInfoContainer linkContainer;

            linkContainer = new LinkInfoList();
            party = new Party(partyID);
            simplusHp = new SimplusHP(10, 100, 10);
            circle = new Circle(new Vector2(posX, posY), radius);

            id++;
            simplus = new SimplusInfo(id, circle, simplusHp, party, linkContainer);
            return simplus;
        }
    }
}
