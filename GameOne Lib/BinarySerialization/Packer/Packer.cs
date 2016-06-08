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
    using SizePacket = UInt16;
    public class Packer: IPacker
    {
        private RegisterPacker _register;

        public Packer()
        {
            _register = new RegisterPacker(); 
        }
        public void CreatePacket(ref Packet packet, IMessageData message)
        {
            packet = null;
            using (MemoryStream stream = new MemoryStream())
            {
                SizePacket size = 0;
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(size);
                    writer.Write(message.Type);
                    IPackerMessage packer = _register.Find(message.Type);
                    if (packer == null) return;
                    packer.CreatePacket(writer, message);
                    size = (SizePacket)(stream.Length - sizeof(SizePacket));
                    stream.Position = 0;
                    writer.Write(size);
                    packet = new Packet(stream.ToArray());
                }
            }
        }
    }
}
