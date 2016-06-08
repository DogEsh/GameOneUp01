using System;
using SimpleTeam.Message;
using System.IO;
using SimpleTeam.GameOne.Message;

namespace SimpleTeam.GameOne.BinarySerialization
{
    using MessageID = Byte;
    public class PackerAccount : IPackerMessage
    {
        MessageID IMessageID.Type
        {
            get
            {
                return (MessageID)HelperMessageID.Account;
            }
        }
        public void CreatePacket(BinaryWriter writer, IMessageData message)
        {
            MessageDataAccount d = (MessageDataAccount)message;
            //writer.Write(m.StateValue);
            writer.Write(d.Success);
            writer.Write((Byte)d.State);
            writer.Write(d.Email);
            writer.Write(d.Password);
            writer.Write(d.Nick);
        }
        
    }
}
