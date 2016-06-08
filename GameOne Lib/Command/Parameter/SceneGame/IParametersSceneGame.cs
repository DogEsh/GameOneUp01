using SimpleTeam.GameOne.Scene;
using SimpleTeam.Command;

namespace SimpleTeam.GameOne.Command
{
    public interface IParameterSceneGame : IParameter
    {
        ISceneGame GetSceneGame();
    }
}

