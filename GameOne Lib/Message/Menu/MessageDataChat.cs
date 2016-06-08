using System;
using SimpleTeam.Message;
using SimpleTeam.GameOne.Parameter;
namespace SimpleTeam.GameOne.Message
{
    using MessageID = Byte;
    using ParameterID = Byte;

    [Serializable]
    public sealed class MessageDataChat : IMessageData
    {
        public MessageID Type
        {
            get
            {
                return (MessageID)HelperMessageID.Chat;
            }
        }
        public ParameterID ParameterType
        {
            get
            {
                return (ParameterID)HelperParameterID.SceneMenu;
            }
        }
        private string _line;
        public MessageDataChat(String line)
        {
            _line = line;
        }
        public String Line
        {
            get
            {
                return _line;
            }
        }
    };
}