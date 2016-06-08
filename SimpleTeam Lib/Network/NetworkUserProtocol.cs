using System.Net.Sockets;
using System;
using SimpleTeam.User;

namespace SimpleTeam.Network
{
    using SizePacket = UInt16;
    /**
    <summary> 
    Обертка на уровне пакетов над TCP протоколом. 
    </summary>
    */
    public class NetworkUserProtocol
    {
        private NetworkStreamParser _parser = new NetworkStreamParser();
        public void Send(IUserNetwork user)
        {
            if (!user.Socket.Connected) return;

            NetworkStream stream = user.Socket.GetStream();
            while (user.PacketsSend.Count != 0)
            {
                Packet packet = user.PacketsSend.Dequeue();
                _parser.SendPacket(packet, stream);
            }
        }
        public void Receive(IUserNetwork user)
        {
            if (!user.Socket.Connected) return;

            NetworkStream stream = user.Socket.GetStream();

            Packet packet = user.PacketReceive;
            _parser.ReceivePacket(packet, stream);

        }
    }
}
