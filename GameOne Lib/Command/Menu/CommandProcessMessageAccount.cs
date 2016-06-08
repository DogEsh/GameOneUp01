using System;
using SimpleTeam.Message;
using SimpleTeam.GameOne.Message;

namespace SimpleTeam.GameOne.Command
{
    using TypeID = Byte;
    /**
    <summary> 
    Обрабатывает сообщения аккаунта, пришедшие из интернета.
    </summary>
    */
    class CommandProcessMessageAccount : CommandProcessMessageAdapterSceneMenu
    {
        public override TypeID Type
        {
            get
            {
                return (TypeID)HelperMessageID.Account;
            }
        }
        protected override void DoMy(IParameterSceneMenu parameter, IMessage message)
        {
            parameter.GetSceneMenu().SetMessage((MessageAccount)message);
        }
    }
}
