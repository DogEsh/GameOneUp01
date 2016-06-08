using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using SimpleTeam.Message;
using SimpleTeam.GameOne.Message.Manager;
using SimpleTeam.SystemBase;
using SimpleTeam.User;
using SimpleTeam.BinarySerialization;
using SimpleTeam.BinarySerialization.DotNet;
using SimpleTeam.Network;

namespace SimpleTeam.GameOne.Network
{
    /**
    <summary> 
    Получает сообщения от менеджера сообщений и отправляет их по назначению.
    <para/>
    Получает сообщения от клиента, складывает в менеджер сообщений, указывая от кого пришло данное сообщение.
    </summary>
    */
    sealed class NetworkServerMachine : StateMachine
    {
        private TcpListener _listener;
        private List<IUserNetwork> _clients;
        private IMessagesManagerNetwork _messagesManager;

        private NetworkUserProtocol _network = new NetworkUserProtocol();

        private PacketConverter _converter;

        public NetworkServerMachine(IMessagesManagerNetwork messagesManager)
        {
            _messagesManager = messagesManager;
            _clients = new List<IUserNetwork>();
            _converter = new PacketConverter(new Packer(), new Unpacker());
        }
        protected override bool Init()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            _listener = new TcpListener(ip, 30);
            _listener.Start();
            return true;
        }
        protected override void Deinit()
        {
            _listener.Stop();
            foreach (IUserNetwork cl in _clients)
            {
                cl.Socket.Close();
            }
        }
        protected override bool DoAnything()
        {
            AddClients();
            SendAll();
            ReceiveAll();
            Thread.Sleep(100);
            return true;
        }
        private void AddClients()
        {
            while (_listener.Pending())
            {
                IUserNetwork cl = new UserClient(_listener.AcceptTcpClient());
                cl.Socket.SendBufferSize = 1024;
                cl.Socket.ReceiveBufferSize = 1024;
                _clients.Add(cl);
            }
        }
        private void SendAll()
        {
            while (true)
            {
                IMessage m = _messagesManager.GetMessage();
                if (m == null) break;
                if (m.Users.Count == 0)
                {
                    m = new MessageRealization(m, new MessageAddress(_clients));
                }
                _converter.ConvertToSend(m);
            }

            foreach (IUserNetwork user in _clients)
            {
                _network.Send(user);
            }
            
        }
        private void ReceiveAll()
        {

            foreach (IUserNetwork user in _clients)
            {
                while (true)
                {
                    _network.Receive(user);
                    IMessage m = null;
                    UnpackerState s = _converter.ConvertToReceive(ref m, user);
                    if (s == UnpackerState.Ok)
                    {
                        _messagesManager.SetMessage(m);
                    }
                    else if (s == UnpackerState.NotReady) break;
                    else
                    {
                        throw new System.SystemException("hoho");
                    }
                }
            }
        }
    }
}
