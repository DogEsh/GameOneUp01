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
    class CommandProcessMessageGameMap : CommandProcessMessageAdapterSceneGame
    {
        public override TypeID Type
        {
            get
            {
                return (TypeID)HelperMessageID.GameMap;
            }
        }
        protected override void DoMy(IParameterSceneGame parameter, IMessage message)
        {
            parameter.GetSceneGame().SetMessage((MessageGameMap)message);
        }
    }
}
