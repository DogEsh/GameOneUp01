using System;
using SimpleTeam.Command;
using SimpleTeam.Message;

namespace SimpleTeam.GameOne.Command
{
    using TypeID = Byte;
    public abstract class CommandProcessMessageAdapterSceneMenu : ICommandProcessMessage
    {
        public abstract byte Type { get; }
        public TypeID GetParameterType()
        {
            return (TypeID)HelperParameterID.SceneMenu;
        }
        public void Do(IParameter parameter, IMessage message)
        {
            DoMy(parameter as IParameterSceneMenu, message);
        }
        protected abstract void DoMy(IParameterSceneMenu parameter, IMessage message);

    }
}
