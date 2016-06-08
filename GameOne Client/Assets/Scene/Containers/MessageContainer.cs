using SimpleTeam.Message;

namespace SimpleTeam.GameOne.Message
{
    public class MessageContainer : IMessageContainer
    {
        private IMessage _message;
        public bool IsEmpty
        {
            get
            {
                return _message == null;
            }
        }
        public IMessage Get()
        {

            IMessage m;
            lock (this)
            {
                m = _message;
                _message = null;
            }
            return m;
            
        }
        public void Set(IMessage message)
        {
            lock (this)
            {
                _message = message;
            }
        }
    }
}
