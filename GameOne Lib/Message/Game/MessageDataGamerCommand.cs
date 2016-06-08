using System;
using SimpleTeam.Message;
using SimpleTeam.GameOne.Parameter;

namespace SimpleTeam.GameOne.Message
{
    using MessageID = Byte;
    using ParameterID = Byte;
    [Serializable]
    public sealed class MessageDataGamerCommand : IMessageData
    {
        public MessageID Type
        {
            get
            {
                return (MessageID)HelperMessageID.GamerCommand;
            }
        }
        public ParameterID ParameterType
        {
            get
            {
                return (ParameterID)HelperParameterID.SceneGame;
            }
        }
    }
}