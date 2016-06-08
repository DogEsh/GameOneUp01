using System;
using SimpleTeam.Command;
using SimpleTeam.Message;

namespace SimpleTeam.GameOne.Command
{
    using TypeID = Byte;
    public abstract class CommandProcessMessageAdapterSceneGame : ICommandProcessMessage
    {
        public abstract byte Type { get; }
        public TypeID GetParameterType()
        {
            return (TypeID)HelperParameterID.SceneGame;
        }
        public void Do(IParameter parameter, IMessage message)
        {
            DoMy(parameter as IParameterSceneGame, message);
        }
        protected abstract void DoMy(IParameterSceneGame parameter, IMessage message);
        
    }
}
