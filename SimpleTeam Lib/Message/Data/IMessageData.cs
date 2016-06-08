using System;
using System.Runtime.Serialization;
namespace SimpleTeam.Message
{
    using ParameterID = Byte;
    public interface IMessageData : IMessageID
    {
        ParameterID ParameterType { get; }
    }
}
