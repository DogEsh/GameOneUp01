using System.Collections.Generic;
using SimpleTeam.User;
using System;

namespace SimpleTeam.Message
{
    /**
    <summary>
    Хранит список юзеров от кого отправлено\кому отправить сообщение.
    </summary>
    */
    [Serializable]
    public abstract class MessageBase : IMessage
    {
        public abstract byte Type { get; }
        [NonSerialized] public List<IUserNetwork> Users;
        protected MessageBase()
        {
            Users = new List<IUserNetwork>();
        }

        
    }
}


 

