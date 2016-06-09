using UnityEngine;
using SimpleTeam.Command;
using System;
using SimpleTeam.Command.Scenario;
using SimpleTeam.GameOne.GameInfo;
using SimpleTeam.Message;

namespace SimpleTeam.GameOne.Scene
{
    public class SceneClientGame : MonoBehaviour, ISceneGame
    {
        //ISceneScenario
        private ISceneScenario _sceneScenario = new SceneScenario();

        public IScenario GetScenario()
        {
            return _sceneScenario.GetScenario();
        }

        //ISceneMessages
        private ISceneMessages _sceneMessages;
        public void SetMessage(IMessage message)
        {
            _sceneMessages.SetMessage(message);
        }


        private void Start()
        {
            IGameMap map = CreateMap();
            map.InitInfo(CreateMapInfo());
            _sceneMessages = new SceneClientGameMessages(map);

            CreateGameManager(map, _sceneScenario.GetScenario());
        }
        private IGameMap CreateMap()
        {
            const string path = "Game/GameMapPrefab";
            GameObject prefab = Resources.Load<GameObject>(path);
            GameObject inst = Instantiate(prefab);
            inst.transform.parent = gameObject.transform;
            return inst.GetComponent<GameMap>();
        }

        private void Update()
        {
        }

        public IMapInfo CreateMapInfo()
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
            circle = new Circle(new Vector2(Screen.height/2, Screen.width/2), 3f);
            simplus = new SimplusInfo(1, circle, simplusHp, party, linkContainer);
            mySimplus = new GameObjList<ISimplusInfo>();
            mySimplus.SetObj(simplus);
            IMapInfo mapInfo = new MapInfo(mySimplus);
            return mapInfo;
        }

        public GameManager CreateGameManager(IGameMap map, IScenario scenario)
        {
            GameManager gameManager;
            const string path = "Game/GameManagerPrefab";
            GameObject prefab = Resources.Load<GameObject>(path);
            GameObject inst = Instantiate(prefab);
            inst.transform.parent = gameObject.transform;
            gameManager = inst.GetComponent<GameManager>();
            gameManager.Initialize(map, scenario);
            return gameManager;
        }
    }
}
