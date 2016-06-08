using System;
using SimpleTeam.User;
using SimpleTeam.Message;
using SimpleTeam.GameOne.Message;
using SimpleTeam.Command;
using SimpleTeam.Command.Scenario;
using SimpleTeam.GameOne.Command;
using SimpleTeam.GameOne.Data;

namespace SimpleTeam.GameOne.Scene
{
    using MessageID = Byte;
    class MessageHandlerServerGamerCommand : IMessageHandler
    {
        public MessageID Type
        {
            get
            {
                return (MessageID)HelperMessageID.GamerCommand;
            }
        }
        MessageHandlerScenario _handlerScenario;
        public MessageHandlerServerGamerCommand(IScenario scenario)
        {
            _handlerScenario = new MessageHandlerScenario(scenario);
        }
        public void SetMessage(IMessage message)
        {
            MessageDataGamerCommand data = message as IMessageData as MessageDataGamerCommand;
        }
    }
}
