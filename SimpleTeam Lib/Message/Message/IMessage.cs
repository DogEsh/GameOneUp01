using System;

namespace SimpleTeam.Message
{
    public interface IMessage
    {
        IMessageData Data { get; }
        IMessageAddress Address { get; }
    }
}
