using System;
using System.Collections.Generic;
using SimpleTeam.Command;
using SimpleTeam.GameOne.Command;
using SimpleTeam.Command.Scenario;
using SimpleTeam.Message;

namespace SimpleTeam.GameOne.Message.Manager
{
    /**
    <summary> 
    Хранит очередь сообщений для отправки в интернет. 
    <para/>
    Хранит очередь доставленных из сети сообщений,
    для которых находит команду для исполнения сеценарной машиной. 
    </summary>
    */
    public class MessagesManager : IMessagesManager
    {
        private IScenario _scenario;
        private Queue<IMessage> _messagesNetwork;


        public MessagesManager()
        {
            _scenario = new ScenarioQueue();
            _messagesNetwork = new Queue<IMessage>();
        }

        void IMessagesManagerNetwork.SetMessage(IMessage message)
        {
            if (message != null)
            {
                ICommand cs = new CommandSendMessageScene(message);
                _scenario.Set(cs);
            }
        }

        IMessage IMessagesManagerNetwork.GetMessage()
        {
            if (_messagesNetwork.Count == 0) return null;
            else
            {
                IMessage m = null;
                lock (_messagesNetwork)
                {
                    m = _messagesNetwork.Dequeue();
                }
                return m;
            }
        } 

        void IMessagesManagerScenario.SetMessage(IMessage message)
        {
            if (message != null)
            {
                lock (_messagesNetwork)
                {
                    _messagesNetwork.Enqueue(message);
                }
            }
        }

        public IScenario GetScenario()
        {
            return _scenario;
        }
    }

}
