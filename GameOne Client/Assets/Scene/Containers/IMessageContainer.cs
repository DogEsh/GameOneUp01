using SimpleTeam.Message;

namespace SimpleTeam.GameOne.Message
{
    public interface IMessageContainer
    {
        IMessage Get();
        void Set(IMessage message);
        bool IsEmpty { get; }
    }
}
