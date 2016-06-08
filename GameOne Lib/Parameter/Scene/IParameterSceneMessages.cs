using SimpleTeam.Parameter;
using SimpleTeam.GameOne.Scene;

namespace SimpleTeam.GameOne.Parameter
{
    public interface IParameterSceneMessages : IParameter
    {
        ISceneMessages GetSceneMessages();
    }
}
