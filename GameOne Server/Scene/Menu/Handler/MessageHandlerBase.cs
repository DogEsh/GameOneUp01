using System;
using SimpleTeam.Command;
using SimpleTeam.GameOne.Command;
using SimpleTeam.Message;
using SimpleTeam.Command.Scenario;
namespace SimpleTeam.GameOne.Scene
{
    using MessageID = Byte;
    public abstract class MessageHandlerBase : IMessageHandler
    {
        public abstract MessageID Type { get; }
        IScenario _scenario;
        public MessageHandlerBase(IScenario scenario)
        {
            _scenario = scenario;
        }
        protected void SendToNetwork(IMessageData data, IMessageAddress address = null)
        {
            IMessage m = new MessageRealization(data, address);
            ICommand c = new CommandSendMessageNetwork(m);
            _scenario.Set(c);
        }

        public abstract void SetMessage(IMessage message);
    }
}
