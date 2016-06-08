using System;
using SimpleTeam.GameOne.Message;
using SimpleTeam.Command.Scenario;
using SimpleTeam.Message;

namespace SimpleTeam.GameOne.Scene
{
    using MessageID = Byte;

    class MessageHandlerClientGameMap : IMessageHandler
    {
        IGameMap _map;

        public MessageID Type
        {
            get
            {
                return (MessageID)HelperMessageID.GameMap;
            }
        }
        public MessageHandlerClientGameMap(IGameMap map)
        {
            _map = map;
        }

        public void SetMessage(IMessage message)
        {
            MessageDataGameMap data = message as IMessageData as MessageDataGameMap;
            if (data.State == MessageDataGameMap.HelperState.Init)
            {
                _map.InitInfo(data.Map);
            }
            else if (data.State == MessageDataGameMap.HelperState.Update)
            {
                _map.UpdateInfo(data.Map);
            }
        }
    }
}

