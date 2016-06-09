using SimpleTeam.Message;
using SimpleTeam.GameOne.Message;
using SimpleTeam.Command.Scenario;
using SimpleTeam.Command;
using SimpleTeam.GameOne.Command;
using System;

namespace SimpleTeam.GameOne.Scene
{
    class LinkManagerCreator : ILinkManager
    {
        ISimplus _source;
        ISimplus _destination;
  
        private IScenario _scenario;

        private void SetSource(ISimplus simplus)
        {
            Clear();
            _source = simplus;
        }

        private void SetDestination(ISimplus simplus)
        {
            _destination = simplus;
            if (_source != null && _destination != null && _destination != _source)
            {
                SendToNetwork();
            }
            Clear();
        }
        private void Clear()
        {
            _source = null;
            _destination = null;
        }
        private void SendToNetwork()
        {
            LinkInfoCreate info = new LinkInfoCreate(_source.GetInfo(), _destination.GetInfo());
            IMessageData data = new MessageDataGamerCommand(info);
            IMessage msg = new MessageRealization(data);
            ICommand cmd = new CommandSendMessageNetwork(msg);
            _scenario.Set(cmd);
        }


        public LinkManagerCreator(IScenario scenario)
        {
            _scenario = scenario;
        }
        public void SetMouse(IMouseManager mouse)
        {
            HelperMouseState state = mouse.State.Get();
            ISimplus focus = mouse.FocusSimplus;

            if (HelperMouseState.Down == state)
            {
                SetSource(focus);
            }
            else if (HelperMouseState.Up == state)
            {
                SetDestination(focus);
            }
        }

    }
}
