using SimpleTeam.Command.Scenario;

namespace SimpleTeam.GameOne.Scene
{
    class SceneClientGameMessages : SceneMessages
    {
        public SceneClientGameMessages()
        {
            base.Add(new MessageHandlerClientGameMap());
            base.Add(new MessageHandlerClientGameState());
        }
    }
}
