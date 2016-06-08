using System;
using SimpleTeam.User;
using SimpleTeam.Message;
using SimpleTeam.GameOne.Message;
using SimpleTeam.Command;
using SimpleTeam.Command.Scenario;
using SimpleTeam.GameOne.Command;
using SimpleTeam.GameOne.Data;

namespace SimpleTeam.GameOne.Scene
{
    using MessageID = Byte;
    class MessageHandlerAccount : MessageHandlerBase
    {
        public override byte Type
        {
            get
            {
                return (MessageID)HelperMessageID.Account;
            }
        }

        DataSet _data;
        
        public MessageHandlerAccount(IScenario scenario) : base(scenario)
        {
            _data = new DataSet();
        }

        public override void SetMessage(IMessage message)
        {
            MessageDataAccount data = message.Data as MessageDataAccount;
            bool success = false;
            UserClient user = message.Address.Users[0] as UserClient;
            if (data.State == MessageDataAccount.StateType.SignUp)
            {
                success = _data.SignUp(data.Email, data.Password, data.Nick);

            }
            else if (data.State == MessageDataAccount.StateType.SignIn)
            {
                IUserProfile p = _data.SignIn(data.Email, data.Password);
                if (p != null)
                {
                    success = true;
                    user.UpdateProfile(p);

                    MessageDataProfile dd = new MessageDataProfile(user.Nick, 0);
                    SendToNetwork(dd, message.Address);
                }
            }
            else if (data.State == MessageDataAccount.StateType.SignOut)
            {
                success = true;
                user.Nick = string.Empty;
            }
            else if (data.State == MessageDataAccount.StateType.ChangePassword)
            {
                if (user.Nick != null)
                {
                    _data.UpdatePassword(user.Nick, data.Password);
                    success = true;
                }
            }
            MessageDataAccount ddd = new MessageDataAccount(data.State, success);
            SendToNetwork(ddd, message.Address);
        }
    }
}

