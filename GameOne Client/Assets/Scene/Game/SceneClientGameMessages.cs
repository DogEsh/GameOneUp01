using SimpleTeam.Command.Scenario;

namespace SimpleTeam.GameOne.Scene
{
    class SceneClientGameMessages : SceneMessages
    {
        public SceneClientGameMessages(IGameMap map)
        {
            base.Add(new MessageHandlerClientGameMap(map));
            base.Add(new MessageHandlerClientGameState());
        }
    }
}
