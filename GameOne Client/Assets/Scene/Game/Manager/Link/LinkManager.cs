using SimpleTeam.Message;
using SimpleTeam.GameOne.Message;
using SimpleTeam.Command.Scenario;
using SimpleTeam.Command;
using SimpleTeam.GameOne.Command;

namespace SimpleTeam.GameOne.Scene
{
    class LinkManager
    {
        private ISimplus _focus;
        private ISimplus _source;
        private ISimplus _destination;

        private IScenario _scenario;

        private void SendToNetwork()
        {
            IMessageData data = new MessageDataGamerCommand();
            IMessage msg = new MessageRealization(data);

            ICommand cmd = new CommandSendMessageNetwork(msg);
        }

        public ISimplus Source
        {
            get
            {
                return _source;
            }
        }
        public ISimplus Destination
        {
            get
            {
                return _destination;
            }
        }
        public ISimplus Focus
        {
            get
            {
                return _focus;
            }
        }


        public MessageLinkOld GetMessage()
        {
            // MessageLinkOld m = _message;
            //_message = null;
            //return m;
            return null;
        }

        private void Clear()
        {
            if (_source != null)
            {
               // _source._wrapper.SetPressed(false);
                _source = null;
            }

            _destination = null;
            //SetAnimation(_focus, SimplusActionState.Focused);
        }
        public void SetMouse(IMouseManager mouse)
        {

        }

        private void SetMouseState(HelperMouseState state)
        {
            if (HelperMouseState.Down == state)
            {
                Clear();
                if (_focus != null)
                {
                    _source = _focus;
                  //  _source._wrapper.SetPressed(true);
                }
            }
            if (HelperMouseState.Up == state)
            {
                if (_source != null && _focus != null && _focus != _source)
                {
                    _destination = _focus;
                   // _message = new MessageLinkOld(this);
                }
                Clear();
            }
        }

        private void SetFocus(ISimplus focus)
        {
            if (focus != _focus)
            {
                if (focus != null)
                {
                    //focus._wrapper.SetFocused(true);
                }
                if (_focus != null)
                {
                   // _focus._wrapper.SetFocused(false);
                }
                //_focus = focus;
            }
        }
        
    }
}
