using System;
using SimpleTeam.GameOne.Message;
using SimpleTeam.Command.Scenario;
using SimpleTeam.Message;

namespace SimpleTeam.GameOne.Scene
{
    using MessageID = Byte;
    class MessageHandlerClientGameMap : IMessageHandler
    {
        GameMap _map;
        public MessageID Type
        {
            get
            {
                return (MessageID)HelperMessageID.GameMap;
            }
        }
        public MessageHandlerClientGameMap()
        {
        }

        public void SetMessage(IMessage message)
        {
            MessageDataGameMap data = message as IMessageData as MessageDataGameMap;
            if (data.State == MessageDataGameMap.HelperState.Init)
            {
                _map.SetToInitInfo(data.Map);
            }
            else if (data.State == MessageDataGameMap.HelperState.Update)
            {
                _map.SetToUpdateInfo(data.Map);
            }
        }
    }
}

