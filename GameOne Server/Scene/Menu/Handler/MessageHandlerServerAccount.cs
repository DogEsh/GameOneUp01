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
    class MessageHandlerServerAccount : IMessageHandler
    {
        public MessageID Type
        {
            get
            {
                return (MessageID)HelperMessageID.Account;
            }
        }


        MessageHandlerScenario _handlerScenario;
        public MessageHandlerServerAccount(IScenario scenario)
        {
            _data = new DataSet();
            _handlerScenario = new MessageHandlerScenario(scenario);
        }
        DataSet _data;
        public void SetMessage(IMessage message)
        {
            MessageDataAccount data = message as IMessageData as MessageDataAccount;
            bool success = false;
            UserClient user = message.Users[0] as UserClient;
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
                    _handlerScenario.SendToNetwork(dd, message);
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
            _handlerScenario.SendToNetwork(ddd, message);
        }
    }
}

