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
    Обрабатывает сообщения игрового профиля, пришедшие из интернета.
    </summary>
    */
    class CommandProcessMessageProfile : CommandProcessMessageAdapterSceneMenu
    {
        public override TypeID Type
        {
            get
            {
                return (TypeID)HelperMessageID.Profile;
            }
        }
        protected override void DoMy(IParameterSceneMenu parameter, IMessage message)
        {
            parameter.GetSceneMenu().SetMessage((MessageProfile)message);
        }
    }
}
