using System;
using SimpleTeam.Message;
using SimpleTeam.GameOne.Parameter;

namespace SimpleTeam.GameOne.Message
{
    using MessageID = Byte;
    using ParameterID = Byte;
    [Serializable]
    public sealed class MessageDataGameState : IMessageData
    {
        public MessageID Type
        {
            get
            {
                return (MessageID)HelperMessageID.GameState;
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