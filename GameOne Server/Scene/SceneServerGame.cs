

using System;
using SimpleTeam.Command;
using SimpleTeam.GameOne.Message;
using SimpleTeam.Command.Scenario;

namespace SimpleTeam.GameOne.Scene
{
    class SceneServerGame : ISceneGame
    {
        //ISceneScenario
        private SceneScenario _sceneScenario = new SceneScenario();

        public IScenario GetScenario()
        {
            return ((ISceneScenario)_sceneScenario).GetScenario();
        }


        //ISceneGameMessages
        void ISceneGameMessages.SetMessage(MessageGamerCommand message)
        {
            throw new NotImplementedException();
        }

        void ISceneGameMessages.SetMessage(MessageGameState message)
        {
            throw new NotImplementedException();
        }

        void ISceneGameMessages.SetMessage(MessageGameMap message)
        {
            throw new NotImplementedException();
        }
    }
}
