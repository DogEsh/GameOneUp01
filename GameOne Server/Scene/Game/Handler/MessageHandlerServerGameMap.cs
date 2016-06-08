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
    class MessageHandlerServerGameMap : IMessageHandler
    {
        public MessageID Type
        {
            get
            {
                return (MessageID)HelperMessageID.GameMap;
            }
        }
        MessageHandlerScenario _handlerScenario;
        public MessageHandlerServerGameMap(IScenario scenario)
        {
            _handlerScenario = new MessageHandlerScenario(scenario);
        }


        public void SetMessage(IMessage message)
        {
            MessageDataGameMap data = message as IMessageData as MessageDataGameMap;
        }
    }
}
