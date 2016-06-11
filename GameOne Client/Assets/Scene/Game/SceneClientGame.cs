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

        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = CreateGameManager(_sceneScenario.GetScenario());
            _sceneMessages = new SceneClientGameMessages(_gameManager);

            
        }
       

        private void Update()
        {
        }

        

        public GameManager CreateGameManager(IScenario scenario)
        {
            GameManager gameManager;
            const string path = "Game/GameManagerPrefab";
            GameObject prefab = Resources.Load<GameObject>(path);
            GameObject inst = Instantiate(prefab);
            inst.transform.parent = gameObject.transform;
            gameManager = inst.GetComponent<GameManager>();
            gameManager.Initialize(scenario);
            return gameManager;
        }
    }
}
