

using System;
using SimpleTeam.Command;
using SimpleTeam.GameOne.Message;
using SimpleTeam.Command.Scenario;
using SimpleTeam.Message;

namespace SimpleTeam.GameOne.Scene
{
    class SceneServerGame : ISceneGame
    {
        //ISceneScenario
        private SceneScenario _sceneScenario;

        public IScenario GetScenario()
        {
            return ((ISceneScenario)_sceneScenario).GetScenario();
        }

        //ISceneMessages
        private ISceneMessages _sceneMessages;
        public void SetMessage(IMessage message)
        {
            _sceneMessages.SetMessage(message);
        }

        public SceneServerGame()
        {
            _sceneScenario = new SceneScenario();
            _sceneMessages = new SceneServerGameMessages(_sceneScenario.GetScenario());
        }
    }
}
