using SimpleTeam.Message;

namespace SimpleTeam.GameOne.Scene
{
    public interface IMessageHandler : IMessageID
    {
        void SetMessage(IMessage message);
    }
}
