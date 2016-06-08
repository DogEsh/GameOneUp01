using System.Net.Sockets;
using System;

namespace SimpleTeam.Network
{
    using SizePacket = UInt16;
    public class NetworkStreamParser
    {
        public bool SendPacket(Packet packet, NetworkStream stream)
        {
            if (!stream.CanWrite) return false;
            if (!packet.IsReady) return false;
            
            Byte[] size = BitConverter.GetBytes(packet.Size);
            Byte[] data = packet.GetData();
            stream.Write(size, 0, size.Length);
            stream.Write(data, 0, data.Length);
            return true;
        }
        public bool ReceivePacket(Packet packet, NetworkStream stream)
        {
            if (!stream.CanRead) return false;
            if (!stream.DataAvailable) return false;

            if (!packet.SizeReady)
            {
                Byte[] buf = BitConverter.GetBytes(packet.Size);
                packet.Pos += (SizePacket)stream.Read(buf, packet.Pos, sizeof(SizePacket) - packet.Pos);
                packet.Size = BitConverter.ToUInt16(buf, 0);
                if (packet.Pos == sizeof(SizePacket))
                {
                    packet.SizeReady = true;
                    packet.Pos = 0;
                }
            }
            if (packet.SizeReady)
            {
                packet.Pos += (SizePacket)stream.Read(packet.GetData(), packet.Pos, packet.Size - packet.Pos);
            }
            if (!packet.IsReady) return false;
            return true;
        }
    }
}
