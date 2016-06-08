using System;
using System.Collections.Generic;
using SimpleTeam.Message;

namespace SimpleTeam.GameOne.Scene
{
    public class SceneMessages : ISceneMessages
    {
        private List<IMessageHandler> _handlers;
        public SceneMessages()
        {
            _handlers = new List<IMessageHandler>();
        }

        public void SetMessage(IMessage message)
        {
            foreach (IMessageHandler h in _handlers)
            {
                if (h.Type == message.Type)
                {
                    h.SetMessage(message);
                }
            }
        }
        public void Add(IMessageHandler handler)
        {
            _handlers.Add(handler);
        }
    }
}
