using System.IO;
using System;
using System.Runtime.Serialization;
using SimpleTeam.Message;
using System.Runtime.Serialization.Formatters.Binary;
using SimpleTeam.Network;

namespace SimpleTeam.BinarySerialization.DotNet
{
    public class Packer:IPacker
    {
        IFormatter formatter;
        public Packer()
        {
            formatter = new BinaryFormatter();
        }


        public void CreatePacket(ref Packet packet, IMessageData message)
        {
            packet = null;
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, message);
                packet = new Packet(stream.ToArray());
            }
        }
    }
}
