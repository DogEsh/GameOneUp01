using SimpleTeam.Command.Scenario;

namespace SimpleTeam.GameOne.Scene
{
    class SceneClientGameMessages : SceneMessages
    {
        public SceneClientGameMessages(IGameManager manager)
        {
            base.Add(new MessageHandlerClientGameMap(manager));
            base.Add(new MessageHandlerClientGameState());
        }
    }
}
