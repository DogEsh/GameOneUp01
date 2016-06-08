using System;
using SimpleTeam.Message;

namespace SimpleTeam.GameOne.Message
{
    using TypeID = Byte;

    [Serializable]
    public sealed class MessageGamerCommand : MessageBase
    {
        public override TypeID Type
        {
            get
            {
                return (TypeID)HelperMessageID.GamerCommand;
            }

        }
    }
}