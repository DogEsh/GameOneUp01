using System;
using SimpleTeam.GameOne.Message;
using SimpleTeam.Command.Scenario;
using SimpleTeam.Message;

namespace SimpleTeam.GameOne.Scene
{
    using MessageID = Byte;
    class MessageHandlerClientGameState : IMessageHandler
    {
        public MessageID Type
        {
            get
            {
                return (MessageID)HelperMessageID.GameState;
            }
        }
        public MessageHandlerClientGameState()
        {
        }

        public void SetMessage(IMessage message)
        {
            MessageDataGameState data = message as IMessageData as MessageDataGameState;
        }
    }
}
