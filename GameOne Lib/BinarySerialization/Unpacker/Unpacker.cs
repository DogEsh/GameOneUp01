using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleTeam.BinarySerialization;
using System.IO;
using SimpleTeam.Network;
using SimpleTeam.Message;


namespace SimpleTeam.GameOne.BinarySerialization
{
    using MessageID = Byte;
    public class Unpacker: IUnpacker
    {
        private RegisterUnpacker _register;
        public Unpacker()
        {
            _register = new RegisterUnpacker();
        }
        public UnpackerState CreateMessageData(ref IMessageData message, Packet packet)
        {
            message = null;
            if (!packet.IsReady) return UnpackerState.NotReady;
            if (packet.Size < sizeof(MessageID)) return UnpackerState.SizeOut;
            using (MemoryStream stream = new MemoryStream(packet.GetData()))
            {
                if (!stream.CanRead) throw new SystemException("haha");
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    MessageID type = reader.ReadByte();
                    IUnpackerMessage unpacker = _register.Find(type);
                    if (unpacker == null) return UnpackerState.NotFoundType;
                    return unpacker.CreateMessageData(ref message, reader, packet.Size);
                }
            }
        }
    }
}
