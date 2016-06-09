using System;
using SimpleTeam.Message;
using SimpleTeam.GameOne.Parameter;

namespace SimpleTeam.GameOne.Message
{
    using MessageID = Byte;
    using ParameterID = Byte;
    [Serializable]
    public sealed class MessageDataGamerCommand : IMessageData
    {
        public MessageID Type
        {
            get
            {
                return (MessageID)HelperMessageID.GamerCommand;
            }
        }
        public ParameterID ParameterType
        {
            get
            {
                return (ParameterID)HelperParameterID.SceneGame;
            }
        }
        public enum HelperInfo : byte
        {
            Create = 0,
            Destroy = 1
        }
        LinkInfoCreate _infoCreate;
        LinkInfoDestroy _infoDestroy;
        byte _stateInfo;
        public HelperInfo StateInfo
        {
            get
            {
                return (HelperInfo)_stateInfo;
            }
        }

        public LinkInfoCreate InfoCreate
        {
            get
            {
                return _infoCreate;
            }
        }
        public LinkInfoDestroy InfoDestroy
        {
            get
            {
                return _infoDestroy;
            }
        }
        public MessageDataGamerCommand(LinkInfoCreate info)
        {
            _stateInfo = (byte)HelperInfo.Create;
            _infoCreate = info;
        }
        public MessageDataGamerCommand(LinkInfoDestroy info)
        {
            _stateInfo = (byte)HelperInfo.Destroy;
            _infoDestroy = info;
        }
    }
}