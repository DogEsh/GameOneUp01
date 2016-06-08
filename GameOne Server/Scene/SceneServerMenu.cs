using System;
using SimpleTeam.Command;
using SimpleTeam.User;
using SimpleTeam.GameOne.Data;
using SimpleTeam.GameOne.Message;
using SimpleTeam.Command.Scenario;
using SimpleTeam.GameOne.Command;

namespace SimpleTeam.GameOne.Scene
{
    /**
    <summary> 
    Обрабатывает события в меню.
    </summary>
    */
    class SceneServerMenu : ISceneMenu
    {
        
        DataSet _data;
        public SceneServerMenu()
        {
            _data = new DataSet();
        }

        //ISceneScenario
        private SceneScenario _sceneScenario = new SceneScenario();

        public IScenario GetScenario()
        {
            return ((ISceneScenario)_sceneScenario).GetScenario();
        }



        //ISceneMenuMessages
        void ISceneMenuMessages.SetMessage(MessageChat message)
        {
            IUserProfile user = message.Users[0] as IUserProfile;
            //if (user.Nick == String.Empty) return;
            
            message.Line = DateTime.Now.ToString("T") + "  <<" + user.Nick + ">>:  " + message.Line;
            message.Users.Clear();
            ICommand c = new CommandSendMessageNetwork(message);
            GetScenario().Set(c);
        }

        void ISceneMenuMessages.SetMessage(MessageAccount message)
        {
            MessageAccount m;
            bool success = false;
            UserClient user = message.Users[0] as UserClient;
            if (message.State == MessageAccount.StateType.SignUp)
            {
                success = _data.SignUp(message.Email, message.Password, message.Nick);
                
            }
            else if (message.State == MessageAccount.StateType.SignIn)
            {
                IUserProfile p = _data.SignIn(message.Email, message.Password);
                if (p != null)
                {
                    success = true;
                    user.UpdateProfile(p);

                    MessageProfile mm = new MessageProfile(user.Nick, 0);
                    mm.Users.Add(message.Users[0]);
                    ICommand cc = new CommandSendMessageNetwork(mm);
                    GetScenario().Set(cc);
                }
            }
            else if (message.State == MessageAccount.StateType.SignOut)
            {
                success = true;
                user.Nick = string.Empty;
            }
            else if (message.State == MessageAccount.StateType.ChangePassword)
            {
                if (user.Nick != null)
                {
                    _data.UpdatePassword(user.Nick, message.Password);
                    success = true;
                }
            }
            m = new MessageAccount(message.State, success);
            m.Users.Add(message.Users[0]);
            ICommand c = new CommandSendMessageNetwork(m);
            GetScenario().Set(c);
        }
        void ISceneMenuMessages.SetMessage(MessageProfile message)
        {
            //nothing
        }
        
    }
}
