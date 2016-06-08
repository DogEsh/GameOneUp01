using SimpleTeam.Command;
using SimpleTeam.GameOne.Message.Manager;

namespace SimpleTeam.GameOne.Command
{
    public interface IParameterMessagesManager : IParameter
    {
        IMessagesManagerScenario GetMessagesManager();
    }
}
