using System;
using SimpleTeam.Command;
using SimpleTeam.GameOne.Command;
using SimpleTeam.Message;
using SimpleTeam.Command.Scenario;
namespace SimpleTeam.GameOne.Scene
{
    using MessageID = Byte;
    public class MessageHandlerScenario
    {
        IScenario _scenario;
        public MessageHandlerScenario(IScenario scenario)
        {
            _scenario = scenario;
        }
        public void SendToNetwork(IMessageData data, IMessageAddress address = null)
        {
            IMessage m = new MessageRealization(data, address);
            ICommand c = new CommandSendMessageNetwork(m);
            _scenario.Set(c);
        }
    }
}
