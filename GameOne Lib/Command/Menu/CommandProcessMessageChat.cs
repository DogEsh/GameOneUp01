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
    Обрабатывает сообщения чата, пришедшие из интернета.
    </summary>
    */
    class CommandProcessMessageChat : CommandProcessMessageAdapterSceneMenu
    {
        public override TypeID Type
        {
            get
            {
                return (TypeID)HelperMessageID.Chat;
            }
        }
        protected override void DoMy(IParameterSceneMenu parameter, IMessage message)
        {
            parameter.GetSceneMenu().SetMessage((MessageChat)message);
        }
    }
}
