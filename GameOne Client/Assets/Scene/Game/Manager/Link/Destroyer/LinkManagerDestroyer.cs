using UnityEngine;
using SimpleTeam.Message;
using SimpleTeam.GameOne.Message;
using SimpleTeam.Command.Scenario;
using SimpleTeam.Command;
using SimpleTeam.GameOne.Command;

namespace SimpleTeam.GameOne.Scene
{
    class LinkManagerDestroyer : ILinkManager
    {
        private IScenario _scenario;

        Vector2 _source;
        bool _okS;
        Vector2 _destination;
        bool _okD;
        private bool IsReady
        {
            get
            {
                return _okD && _okS;
            }
        }

        private void Clear()
        {
            _okS = false;
            _okD = false;
        }

        private void SetSource(Vector2 pos)
        {
            Clear();
            _source = pos;
            _okS = true;
        }
        private void SetDestination(Vector2 pos)
        {
            _destination = pos;
            _okD = true;
            if (IsReady)
            {
                SendToNetwork();
            }
            Clear();
        }

        private void SendToNetwork()
        {
            IMessageData data = new MessageDataGamerCommand();
            IMessage msg = new MessageRealization(data);
            ICommand cmd = new CommandSendMessageNetwork(msg);
            _scenario.Set(cmd);
        }

        public LinkManagerDestroyer(IScenario scenario)
        {
            _scenario = scenario;
        }

        public void SetMouse(IMouseManager mouse)
        {
            HelperMouseState state = mouse.State.Get();
            ISimplus focus = mouse.FocusSimplus;
            Vector2 pos = mouse.Pos;

            if (HelperMouseState.Down == state && focus == null)
            {

                SetSource(pos);
            }
            else if (HelperMouseState.Up == state)
            {
                SetDestination(pos);
            }
        }


      
    }
}
