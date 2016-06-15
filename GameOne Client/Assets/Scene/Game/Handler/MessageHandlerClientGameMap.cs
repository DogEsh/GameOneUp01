using System;
using SimpleTeam.GameOne.Message;
using SimpleTeam.Command.Scenario;
using SimpleTeam.Message;
using SimpleTeam.GameOne.GameInfo;

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
            IGameMapHandler handler = _manager.GetMap().GetComponentInChildren<IGameMapHandler>();
            if (data.State == MessageDataGameMap.HelperState.Init)
            {
                handler.SetToInitInfo(data.Map);
            }
            else if (data.State == MessageDataGameMap.HelperState.Update)
            {
                handler.SetToUpdateInfo(data.Map);
            }
        }
    }
}

