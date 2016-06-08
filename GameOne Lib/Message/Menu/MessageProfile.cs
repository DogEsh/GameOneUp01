using System;
using SimpleTeam.Message;

namespace SimpleTeam.GameOne.Message
{
    using TypeID = Byte;

    [Serializable]
    public sealed class MessageProfile : MessageBase
    {
        public override TypeID Type
        {
            get
            {
                return (TypeID)HelperMessageID.Profile;
            }
        }
        private String _nick;
        private UInt32 _honor;

        public MessageProfile(String nick, UInt32 honor)
        {
            _nick = nick;
            _honor = honor;
        }


        public string Nick
        {
            get
            {
                return _nick;
            }
            set
            {
                _nick = value;
            }
        }
        public UInt32 Honor
        {
            get
            {
                return _honor;
            }
            set
            {
                _honor = value;
            }
        }
    }
    

}
