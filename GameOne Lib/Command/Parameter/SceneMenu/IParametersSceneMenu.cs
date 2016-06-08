using SimpleTeam.GameOne.Scene;
using SimpleTeam.Command;

namespace SimpleTeam.GameOne.Command
{
    public interface IParameterSceneMenu : IParameter
    {
        ISceneMenu GetSceneMenu();
    }
}
