using SimpleTeam.GameOne.Scene;
using System;

namespace SimpleTeam.GameOne.Parameter
{
    using SimpleTeam.Command.Scenario;
    using ParameterID = Byte;
    public class ParameterSceneGame : IParameterSceneGame
    {
        public ParameterID Type
        {
            get
            {
                return (ParameterID)HelperParameterID.SceneGame;
            }
        }
        ISceneGame _scene;
        public ParameterSceneGame(ISceneGame scene)
        {
            _scene = scene;
        }
        public ISceneGame GetScene()
        {
            return _scene;
        }

        public IScenario GetScenario()
        {
            return _scene.GetScenario();
        }

        public ISceneMessages GetSceneMessages()
        {
            return this.GetScene();
        }
    }
}
