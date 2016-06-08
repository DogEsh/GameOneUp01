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
    class MessageHandlerChat : MessageHandlerBase
    {
        public override byte Type
        {
            get
            {
                return (MessageID)HelperMessageID.Chat;
            }
        }
        
        public MessageHandlerChat(IScenario scenario) : base(scenario)
        {
        }

        public override void SetMessage(IMessage message)
        {
            MessageDataChat data = message.Data as MessageDataChat;
          
            IUserProfile user = message.Address.Users[0] as IUserProfile;
            //if (user.Nick == String.Empty) return;
            String tmp = DateTime.Now.ToString("T") + "  <<" + user.Nick + ">>:  " + data.Line;
            MessageDataChat d = new MessageDataChat(tmp);
            SendToNetwork(d);

        }
    }
}
