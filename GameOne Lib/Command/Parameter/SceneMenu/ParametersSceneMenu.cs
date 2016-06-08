using SimpleTeam.GameOne.Scene;
using System;

namespace SimpleTeam.GameOne.Command
{
    using SimpleTeam.Command.Scenario;
    using TypeID = Byte;
    public class ParameterSceneMenu : IParameterSceneMenu
    {
        public TypeID Type
        {
            get
            {
                return (TypeID)HelperParameterID.SceneMenu;
            }
        }

        ISceneMenu _scene;
        public ParameterSceneMenu(ISceneMenu scene)
        {
            _scene = scene;
        }
        public ISceneMenu GetSceneMenu()
        {
            return _scene;
        }

        public IScenario GetScenario()
        {
            return _scene.GetScenario();
        }
    }
}