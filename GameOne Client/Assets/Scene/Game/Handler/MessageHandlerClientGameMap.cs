using System;
using SimpleTeam.GameOne.Message;
using SimpleTeam.Command.Scenario;
using SimpleTeam.Message;

namespace SimpleTeam.GameOne.Scene
{
    using MessageID = Byte;

    class MessageHandlerClientGameMap : IMessageHandler
    {
        IGameManager _manager;

        public MessageID Type
        {
            get
            {
                return (MessageID)HelperMessageID.GameMap;
            }
        }
        public MessageHandlerClientGameMap(IGameManager manager)
        {
            _manager = manager;
        }

        public void SetMessage(IMessage message)
        {
            MessageDataGameMap data = message as IMessageData as MessageDataGameMap;
            if (data.State == MessageDataGameMap.HelperState.Init)
            {
                _manager.GetMap().InitInfo(data.Map);
            }
            else if (data.State == MessageDataGameMap.HelperState.Update)
            {
                _manager.GetMap().UpdateInfo(data.Map);
            }
        }
    }
}

