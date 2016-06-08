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

        ParameterID IMessageData.ParameterType
        {
            get
            {
                return _data.ParameterType;
            }
        }

        MessageID IMessageID.Type
        {
            get
            {
                return _data.Type;
            }
        }

        List<IUserNetwork> IMessageAddress.Users
        {
            get
            {
                return _address.Users;
            }
        }
    }
}


 

