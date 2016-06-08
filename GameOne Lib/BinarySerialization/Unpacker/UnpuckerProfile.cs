using System;
using System.IO;
using SimpleTeam.Message;
using SimpleTeam.Network;
using SimpleTeam.GameOne.Message;
using SimpleTeam.BinarySerialization;

namespace SimpleTeam.GameOne.BinarySerialization
{
    using SizePacket = UInt16;
    using MessageID = Byte;
    public class UnpackerProfile : IUnpackerMessage
    {
        MessageID IMessageID.Type
        {
            get
            {
                return (MessageID)HelperMessageID.Profile;
            }
        }
        public UnpackerState CreateMessageData(ref IMessageData message, BinaryReader reader, SizePacket size)
        {
            String nick = reader.ReadString();
            if (reader.BaseStream.Position >= size) return UnpackerState.SizeOut;
            UInt32 honor = reader.ReadUInt32();
            if (reader.BaseStream.Position != size) return UnpackerState.SizeOut;
            message = new MessageDataProfile(nick, honor);
            return UnpackerState.Ok;
        }

    }
}
