using SimpleTeam.Command;
using SimpleTeam.Message;
using System;

namespace SimpleTeam.GameOne.Command
{
    using TypeID = Byte;
    public interface ICommandProcessMessage : ITypeID
    {
        void Do(IParameter parameter, IMessage message);
        TypeID GetParameterType();
    }
}
