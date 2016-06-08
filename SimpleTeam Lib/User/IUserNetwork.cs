using System.Collections.Generic;
using System.Net.Sockets;
using SimpleTeam.Network;

namespace SimpleTeam.User
{
    public interface IUserNetwork
    {
        TcpClient Socket { get; set; }
        Queue<Packet> PacketsSend { get; }
        Packet PacketReceive { get; }
    }
}
