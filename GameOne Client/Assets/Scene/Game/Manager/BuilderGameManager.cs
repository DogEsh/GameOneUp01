using SimpleTeam.Command.Scenario;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    class BuilderGameManager : MonoBehaviour
    {
        public GameManager Create(IGameMap map, IScenario scenario)
        {
            GameManager gameManager;
            const string path = "Game/GameManagerPrefab";
            GameObject prefab = Resources.Load<GameObject>(path);
            GameObject inst = Instantiate(prefab);
            gameManager = inst.GetComponent<GameManager>();
            gameManager.Initialize(map, scenario);
            return gameManager;
        }
    }
}
