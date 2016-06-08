using SimpleTeam.Command.Scenario;
using SimpleTeam.Message;


namespace SimpleTeam.GameOne.Message.Manager
{
    /**
    <summary> 
    Переферия для внутренних сообщеий.
    </summary>
    */
    public interface IMessagesManagerScenario
    {
        void SetMessage(IMessage message);
        IScenario GetScenario();
    }
}
