using SimpleTeam.Message;
using SimpleTeam.Command.Scenario;

namespace SimpleTeam.GameOne.Scene
{
    class SceneServerGameMessages : SceneMessages
    {
        public SceneServerGameMessages(IScenario scenario)
        {
            base.Add(new MessageHandlerServerGamerCommand(scenario));
            base.Add(new MessageHandlerServerGameState(scenario));
        }
    }
}
