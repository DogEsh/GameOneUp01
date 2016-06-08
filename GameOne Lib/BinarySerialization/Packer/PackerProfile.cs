using System;
using System.IO;
using SimpleTeam.Message;
using SimpleTeam.GameOne.Message;

namespace SimpleTeam.GameOne.BinarySerialization
{
    using MessageID = Byte;
    class PackerProfile : IPackerMessage
    {
        MessageID IMessageID.Type
        {
            get
            {
                return (MessageID)HelperMessageID.Profile;
            }
        }
        public void CreatePacket(BinaryWriter writer, IMessageData message)
        {
            MessageDataProfile m = (MessageDataProfile)message;
            writer.Write(m.Nick);
            writer.Write(m.Honor);
        }
    }
}
