using System;
using SimpleTeam.Message;
using SimpleTeam.GameOne.Parameter;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Message
{
    using ParameterID = Byte;
    using MessageID = Byte;

    [Serializable]
    public sealed class MessageDataGameMap : IMessageData
    {
        public MessageID Type
        {
            get
            {
                return (MessageID)HelperMessageID.GameMap;
            }
        }
        public ParameterID ParameterType
        {
            get
            {
                return (ParameterID)HelperParameterID.SceneGame;
            }
        }
        public enum HelperState : byte
        {
            Init = 0,
            Update = 1
        }
        public MessageDataGameMap(IMapInfo mapInfo, HelperState state)
        {
            _mapInfo = mapInfo;
            _state = (byte)state;
        }

        private byte _state;
        private IMapInfo _mapInfo;
        public HelperState State
        {
            get
            {
                return (HelperState)_state;
            }
        }
        public IMapInfo Map
        {
            get
            {
                return _mapInfo;
            }
        }
    }
}
