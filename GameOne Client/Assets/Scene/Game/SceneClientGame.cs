using UnityEngine;
using SimpleTeam.Command;
using System;
using SimpleTeam.Command.Scenario;
using SimpleTeam.GameOne.Message;
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

        //GameManager
        GameManager _gameManager;
        private void Start()
        {
            IGameMap m = CreateMap();
            CreateGameManager(m);
            _sceneMessages = new SceneClientGameMessages(m);
            
        }
        private IGameMap CreateMap()
        {
            const string path = "Game/GameMapPrefab";
            GameObject prefab = Resources.Load<GameObject>(path);
            GameObject inst = Instantiate(prefab);
            return inst.GetComponent<GameMap>();
        }
        private void CreateGameManager(IGameMap map)
        {
            const string path = "Game/GameManagerPrefab";
            GameObject prefab = Resources.Load<GameObject>(path);
            GameObject inst = Instantiate(prefab);
            _gameManager = inst.GetComponent<GameManager>();
            _gameManager.SetMap(map);
        }

        private void Update()
        {
        }
    }
}
