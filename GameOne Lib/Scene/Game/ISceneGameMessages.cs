using SimpleTeam.GameOne.Message;

namespace SimpleTeam.GameOne.Scene
{
    public interface ISceneGameMessages
    {
        void SetMessage(MessageGameMap message);
        void SetMessage(MessageGameState message);
        void SetMessage(MessageGamerCommand message);
    }
}
