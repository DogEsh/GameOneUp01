using System;
using SimpleTeam.Message;
using SimpleTeam.Network;

namespace SimpleTeam.BinarySerialization
{
    public enum UnpackerState : byte
    {
        Ok = 0,
        NotReady = 1,
        NotFoundType = 2,
        SizeOut = 3,
        NotParse = 4
    }
    public interface IUnpacker
    {
        UnpackerState CreateMessageData(ref IMessageData message, Packet packet);
    }
}
