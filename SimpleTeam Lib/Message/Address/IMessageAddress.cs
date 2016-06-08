using System.Collections.Generic;
using SimpleTeam.User;

namespace SimpleTeam.Message
{
    public interface IMessageAddress
    {
        List<IUserNetwork> Users { get; }
    }
}
