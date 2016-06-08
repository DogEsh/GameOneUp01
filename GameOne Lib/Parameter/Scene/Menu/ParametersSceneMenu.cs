using SimpleTeam.GameOne.Scene;
using System;

namespace SimpleTeam.GameOne.Parameter
{
    using SimpleTeam.Command.Scenario;
    using ParameterID = Byte;
    public class ParameterSceneMenu : IParameterSceneMenu
    {
        public ParameterID Type
        {
            get
            {
                return (ParameterID)HelperParameterID.SceneMenu;
            }
        }

        ISceneMenu _scene;
        public ParameterSceneMenu(ISceneMenu scene)
        {
            _scene = scene;
        }
        public ISceneMenu GetScene()
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