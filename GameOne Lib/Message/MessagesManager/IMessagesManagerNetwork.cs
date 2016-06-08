using SimpleTeam.Message;


namespace SimpleTeam.GameOne.Message.Manager
{
    /**
    <summary> 
    Периферия для интернета.
    </summary>
    */
    public interface IMessagesManagerNetwork
    {
        void SetMessage(IMessage message);
        IMessage GetMessage();
    }
}
