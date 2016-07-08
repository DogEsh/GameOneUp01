using System.Collections.Generic;
using SimpleTeam.User;
using System;

namespace SimpleTeam.Message
{
    using MessageID = Byte;
    using ParameterID = Byte;
    /**
    <summary>
    Хранит список юзеров от кого отправлено\кому отправить сообщение.
    </summary>
    */
    public class MessageRealization : IMessage
    {
        public IMessageAddress _address;
        public IMessageData _data;

        public MessageRealization(IMessageData data, IMessageAddress address = null)
        {
            _data = data;
            if (address == null)
            {
                _address = new MessageAddress();
            }
            else _address = address;
        }

        public IMessageAddress Address
        {
            get
            {
                return _address;
            }
        }

        public IMessageData Data
        {
            get
            {
                return _data;
            }
        }
    }
}


 

