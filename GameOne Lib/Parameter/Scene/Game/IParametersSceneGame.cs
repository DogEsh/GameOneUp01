using SimpleTeam.GameOne.Scene;
using SimpleTeam.Command;
using SimpleTeam.Parameter;

namespace SimpleTeam.GameOne.Parameter
{
    public interface IParameterSceneGame : IParameterSceneMessages
    {
        ISceneGame GetScene();
    }
}

