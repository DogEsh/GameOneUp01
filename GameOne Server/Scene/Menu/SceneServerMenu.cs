using System;
using SimpleTeam.Command;
using SimpleTeam.User;
using SimpleTeam.GameOne.Data;
using SimpleTeam.GameOne.Message;
using SimpleTeam.Command.Scenario;
using SimpleTeam.GameOne.Command;
using SimpleTeam.Message;

namespace SimpleTeam.GameOne.Scene
{
    /**
    <summary> 
    Обрабатывает события в меню.
    </summary>
    */
    class SceneServerMenu : ISceneMenu
    {
        //ISceneScenario
        private ISceneScenario _sceneScenario;

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

        public SceneServerMenu()
        {
            _sceneScenario = new SceneScenario();
            _sceneMessages = new SceneServerMenuMessages(_sceneScenario.GetScenario());
        }
    }
}
