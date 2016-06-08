using System;
using SimpleTeam.User;
using SimpleTeam.Message;
using SimpleTeam.GameOne.Message;
using SimpleTeam.Command;
using SimpleTeam.Command.Scenario;
using SimpleTeam.GameOne.Command;

namespace SimpleTeam.GameOne.Scene
{
    using MessageID = Byte;
    class MessageHandlerServerChat : IMessageHandler
    {
        public byte Type
        {
            get
            {
                return (MessageID)HelperMessageID.Chat;
            }
        }
        MessageHandlerScenario _handlerScenario;
        public MessageHandlerServerChat(IScenario scenario)
        {
            _handlerScenario = new MessageHandlerScenario(scenario);
        }

        public void SetMessage(IMessage message)
        {
            MessageDataChat data = message as IMessageData as MessageDataChat;
          
            IUserProfile user = message.Users[0] as IUserProfile;
            //if (user.Nick == String.Empty) return;
            String tmp = DateTime.Now.ToString("T") + "  <<" + user.Nick + ">>:  " + data.Line;
            MessageDataChat d = new MessageDataChat(tmp);
            _handlerScenario.SendToNetwork(d);

        }
    }
}
