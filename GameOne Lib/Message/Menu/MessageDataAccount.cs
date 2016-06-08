using System;
using SimpleTeam.Message;
using SimpleTeam.GameOne.Parameter;
namespace SimpleTeam.GameOne.Message
{
    using MessageID = Byte;
    using ParameterID = Byte;

    [Serializable]
    public sealed class MessageDataAccount : IMessageData
    {
        public MessageID Type
        {
            get
            {
                return (MessageID)HelperMessageID.Account;
            }
        }
        public ParameterID ParameterType
        {
            get
            {
                return (ParameterID)HelperParameterID.SceneMenu;
            }
        }
        public enum StateType : byte
        {
            SignUp = 0,
            SignIn = 1,
            SignOut = 2,
            ChangePassword = 3
        }

        /*
        private struct _Flags
        {
            [BitfieldLength(2)]
            public Byte Type;
            [BitfieldLength(1)]
            public bool Success;
        };

        [StructLayout(LayoutKind.Explicit)]
        private struct _State
        {
            [FieldOffset(0)]
            public Byte Value;
            [FieldOffset(0)]
            public _Flags Flags;
        }
        */
        private bool _success;
        private byte _state;
        //private _State _state;
        private String _email;
        private String _password;
        private String _nick;
        
        //unpacker
        public MessageDataAccount(String email, String password, String nick, bool success, byte type)//Byte value)
        {
            _email = email;
            _nick = nick;
            _password = password;
            _success = success;
            _state = type;
            //_state.Value = value;
        }
        
        //client
        public MessageDataAccount(StateType type, String email, String password, String nick = "")
        {
            _email = email;
            _nick = nick;
            _password = password;
            _state = (Byte)type;
            //_state.Flags.Type = (Byte)type;
        }
        //server
        public MessageDataAccount(StateType type, bool success = true, String nick = "")
        {
            _nick = nick;
            _email = String.Empty;
            _password = String.Empty;
            _state = (Byte)type;
            _success = success;
            //_state.Flags.Type = (Byte)type;
            //_state.Flags.Success = success;
        }
        /*
        public Byte StateValue
        {
            get
            {
                return _state.Value;
            }
            set
            {
                _state.Value = value;
            }
        }
        */
        public StateType State
        {
            get
            {
                //return (StateType)_state.Flags.Type;
                return (StateType)_state;
            }
        }
        public bool Success
        {
            get
            {
                return _success;
                //return _state.Flags.Success;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
        }
        public string Nick
        {
            get
            {
                return _nick;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
        }
    }
}
