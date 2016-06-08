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
    public class UnpackerAccount: IUnpackerMessage
    {
        MessageID IMessageID.Type
        {
            get
            {
                return (MessageID)HelperMessageID.Account;
            }
        }
        public UnpackerState CreateMessageData(ref IMessageData message, BinaryReader reader, SizePacket size)
        {
            bool success = reader.ReadBoolean();
            if (reader.BaseStream.Position >= size) return UnpackerState.SizeOut;
            Byte type = reader.ReadByte();
            if (reader.BaseStream.Position >= size) return UnpackerState.SizeOut;
            //Byte value = reader.ReadByte();
            //if (reader.BaseStream.Position >= size) return UnpackerState.SizeOut;
            String email = reader.ReadString();
            if (reader.BaseStream.Position >= size) return UnpackerState.SizeOut;
            String password = reader.ReadString();
            if (reader.BaseStream.Position >= size) return UnpackerState.SizeOut;
            String nick = reader.ReadString();
            if (reader.BaseStream.Position != size) return UnpackerState.SizeOut;
            IMessageData d = new MessageDataAccount(email, password, nick, success, type);

            message = new MessageDataAccount(email, password, nick, success, type);//value);
            return UnpackerState.Ok;
        }
        
    }
}
