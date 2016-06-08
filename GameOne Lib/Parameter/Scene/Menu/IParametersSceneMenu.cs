using SimpleTeam.GameOne.Scene;
using SimpleTeam.Parameter;


namespace SimpleTeam.GameOne.Parameter
{
    public interface IParameterSceneMenu : IParameterSceneMessages
    {
        ISceneMenu GetScene();
    }
}
