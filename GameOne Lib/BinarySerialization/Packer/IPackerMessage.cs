using System;
using SimpleTeam.Message;

using System.IO;

namespace SimpleTeam.GameOne.BinarySerialization
{
    public interface IPackerMessage : IMessageID
    {
        void CreatePacket(BinaryWriter writer, IMessageData message);
    }
}
