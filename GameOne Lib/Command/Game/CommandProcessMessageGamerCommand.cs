using System;
using SimpleTeam.Command;
using SimpleTeam.Message;
using SimpleTeam.GameOne.Message;
using SimpleTeam.Command.Scenario;

namespace SimpleTeam.GameOne.Command
{
    using TypeID = Byte;
    /**
    <summary> 
    Обрабатывает сообщения, пришедшие из интернета.
    </summary>
    */
    class CommandProcessMessageGamerCommand : CommandProcessMessageAdapterSceneGame
    {
        public override TypeID Type
        {
            get
            {
                return (TypeID)HelperMessageID.GamerCommand;
            }
        }
        protected override void DoMy(IParameterSceneGame parameter, IMessage message)
        {
            parameter.GetSceneGame().SetMessage((MessageGamerCommand)message);
        }
    }
}