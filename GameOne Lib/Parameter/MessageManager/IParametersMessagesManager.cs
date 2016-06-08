using SimpleTeam.Parameter;
using SimpleTeam.GameOne.Message.Manager;

namespace SimpleTeam.GameOne.Parameter
{
    public interface IParameterMessagesManager : IParameter
    {
        IMessagesManagerScenario GetMessagesManager();
    }
}
