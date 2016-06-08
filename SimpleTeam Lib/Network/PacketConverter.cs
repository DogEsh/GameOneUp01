using SimpleTeam.Message;
using SimpleTeam.BinarySerialization;
using SimpleTeam.User;
using System.Collections.Generic;

namespace SimpleTeam.Network
{

    public class PacketConverter
    {
        private IPacker _packer;
        private IUnpacker _unpacker;
        public PacketConverter(IPacker packer, IUnpacker unpacker)
        {
            _packer = packer;
            _unpacker = unpacker;
        }
        public void ConvertToSend(IMessage message)
        {
            Packet p = null;
            _packer.CreatePacket(ref p, message);
            foreach (IUserNetwork user in message.Users)
            {
                user.PacketsSend.Enqueue(p);
            }
        }
        public UnpackerState ConvertToReceive(ref IMessage message, IUserNetwork user)
        {
            IMessageData d = null;
            Packet p = user.PacketReceive;
            UnpackerState s = _unpacker.CreateMessageData(ref d, p);
            if (s == UnpackerState.Ok)
            {
                message = new MessageRealization(d, new MessageAddress(user));
            }
            user.PacketReceive.Clear();
            return s;
        }
    }
}
