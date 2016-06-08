using System;
using System.Collections.Generic;
using SimpleTeam.User;

namespace SimpleTeam.Message
{
    public class MessageAddress : IMessageAddress
    {
        private List<IUserNetwork> _users;
        public MessageAddress()
        {
            _users = new List<IUserNetwork>();
        }
        public MessageAddress(IUserNetwork user)
        {
            _users = new List<IUserNetwork>();
            _users.Add(user);
        }
        public MessageAddress(List<IUserNetwork> users)
        {
            _users = users;
        }
        public List<IUserNetwork> Users
        {
            get
            {
                return _users;
            }
        }
    }
}
