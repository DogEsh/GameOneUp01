using System.Collections.Generic;
using System.Net.Sockets;
using SimpleTeam.Network;

namespace SimpleTeam.User
{
    /**
    <summary> 
    Хранит все данные для интернет протокола.
    </summary>
    */
    public class UserNetwork : IUserNetwork
    {
        public TcpClient Socket { get; set; }
        public Queue<Packet> PacketsSend { get; set; }
        public Packet PacketReceive { get; set; }

        public UserNetwork(TcpClient client = null)
        {
            PacketsSend = new Queue<Packet>();
            PacketReceive = new Packet();
            if (client == null)
            {
                Socket = new TcpClient();
            }
            else
            {
                Socket = client;
            }
        }
            
    }
}
