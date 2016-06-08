using SimpleTeam.GameOne.Scene;
using System;

namespace SimpleTeam.GameOne.Command
{
    using SimpleTeam.Command.Scenario;
    using TypeID = Byte;
    public class ParameterSceneGame : IParameterSceneGame
    {
        public TypeID Type
        {
            get
            {
                return (TypeID)HelperParameterID.SceneGame;
            }
        }
        ISceneGame _scene;
        public ParameterSceneGame(ISceneGame scene)
        {
            _scene = scene;
        }
        public ISceneGame GetSceneGame()
        {
            return _scene;
        }

        public IScenario GetScenario()
        {
            return _scene.GetScenario();
        }
    }
}
