using System;
using System.IO;
using SimpleTeam.Message;
using SimpleTeam.GameOne.Message;

namespace SimpleTeam.GameOne.BinarySerialization
{
    using MessageID = Byte;
    public class PackerChat : IPackerMessage
    {
        MessageID IMessageID.Type
        {
            get
            {
                return (MessageID)HelperMessageID.Chat;
            }
        }
        public void CreatePacket(BinaryWriter writer, IMessageData message)
        {
            MessageDataChat m = (MessageDataChat)message;
            writer.Write(m.Line);
        }
        public PackerChat()
        { }
    }
}
