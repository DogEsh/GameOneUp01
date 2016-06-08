using UnityEngine;
using UnityEngine.UI;
using SimpleTeam.Message;
using SimpleTeam.Command;
using SimpleTeam.GameOne.Message;
using SimpleTeam.Command.Scenario;
using SimpleTeam.GameOne.Command;
using System;

namespace SimpleTeam.GameOne.Scene
{
    using MessageID = Byte;
    public class GUISign : MonoBehaviour, IMessageHandler
    {
        public SceneClientMenu Menu;
        public IMessageContainer _container = new MessageContainer();

        private MessageDataAccount.StateType _state;

        public GameObject ObjEmail;
        public GameObject ObjPassword;
        public GameObject ObjNick;
        public GameObject ObjSign;
        public GameObject ObjInfo;
        public GameObject ObjOk;

        public ButtonSign BtnSign;

        public InputField InputEmail;
        public InputField InputNick;
        public InputField InputPassword;

        public Text TextInfo;

        public byte Type
        {
            get
            {
                return (MessageID)HelperMessageID.Account;
            }
        }
        public void SetMessage(IMessage message)
        {
            _container.Set(message);
        }

        public void SetState(MessageDataAccount.StateType state)
        {
            if (state == MessageDataAccount.StateType.SignIn)
            {
                SetStateSignIn();
            }
            else if (state == MessageDataAccount.StateType.SignUp)
            {
                SetStateSignUp();
            }
            else if (state == MessageDataAccount.StateType.SignOut)
            {
                SetStateSignOut();
            }
            else if (state == MessageDataAccount.StateType.ChangePassword)
            {
                SetStateChangePassword();
            }
        }
        private void SetStateSignIn()
        {
            _state = MessageDataAccount.StateType.SignIn;
            SetStateAllOff();
            ObjEmail.SetActive(true);
            ObjPassword.SetActive(true);
            BtnSign.SetState(_state);
            ObjSign.SetActive(true);
        }
        private void SetStateSignUp()
        {
            _state = MessageDataAccount.StateType.SignUp;
            SetStateAllOff();
            ObjEmail.SetActive(true);
            ObjPassword.SetActive(true);
            ObjNick.SetActive(true);
            BtnSign.SetState(_state);
            ObjSign.SetActive(true);
        }
        private void SetStateSignOut()
        {
            _state = MessageDataAccount.StateType.SignOut;
            SetStateAllOff();
            BtnSign.SetState(_state);
            ObjSign.SetActive(true);
            SendToServer();
        }
        private void SetStateChangePassword()
        {
            _state = MessageDataAccount.StateType.ChangePassword;
            SetStateAllOff();
            ObjPassword.SetActive(true);
            BtnSign.SetState(_state);
            ObjSign.SetActive(true);
        }

        private void SetStateAllOff()
        {
            ObjEmail.SetActive(false);
            ObjPassword.SetActive(false);
            ObjNick.SetActive(false);
            ObjSign.SetActive(false);
            ObjInfo.SetActive(false);
            ObjOk.SetActive(false);
        }
        public void Clear()
        {
            InputEmail.text = string.Empty;
            InputNick.text = string.Empty;
            InputPassword.text = string.Empty;
            TextInfo.text = string.Empty;
        }
        public void SendToServer()
        {
            IMessageData data = new MessageDataAccount(_state, InputEmail.text, InputPassword.text, InputNick.text);
            TextInfo.text = "Wait...";
            ObjInfo.SetActive(true);

            IMessage m = new MessageRealization(data);
            ICommand c = new CommandSendMessageNetwork(m);
            IScenario s = Menu.GetScenario();
            s.Set(c);
        }
        public void Update()
        {
            if (_container.IsEmpty) return;
            MessageDataAccount m = _container.Get() as IMessageData as MessageDataAccount;

            if (m.State == _state)
            {
                if (m.Success)
                {
                    SetStateAllOff();
                    TextInfo.text = "Luck!";
                    ObjInfo.SetActive(true);
                    ObjOk.SetActive(true);
                    
                }
                else
                {
                    TextInfo.text = "Error, try again";
                }
            }
            if (m.State == MessageDataAccount.StateType.SignIn)
            {
                Menu.SetStateSignIn(m.Success);
            }
            else if(m.State == MessageDataAccount.StateType.SignOut)
            {
                Menu.SetStateSignIn(!m.Success);
            }
        }

       
    }
}
