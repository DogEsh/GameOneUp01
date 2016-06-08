using System;
using SimpleTeam.Message;

namespace SimpleTeam.GameOne.Message
{
    using TypeID = Byte;

    [Serializable]
    public sealed class MessageGameMap : MessageBase
    {
        public override TypeID Type
        {
            get
            {
                return (TypeID)HelperMessageID.GameMap;
            }
        }
    }
}
