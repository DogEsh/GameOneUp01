using UnityEngine;
using UnityEngine.UI;
using SimpleTeam.Message;
using SimpleTeam.GameOne.Message;

namespace SimpleTeam.GameOne.Scene
{
    public class ButtonSign : MonoBehaviour
    {
        public Text TextButton;

        public void SetState(MessageDataAccount.StateType state)
        {
            if (state == MessageDataAccount.StateType.SignIn)
            {
                TextButton.text = "SignIn";
            }
            else if (state == MessageDataAccount.StateType.SignUp)
            {
                TextButton.text = "SignUp";
            }
            else if (state == MessageDataAccount.StateType.SignOut)
            {
                TextButton.text = "SignOut";
            }
            else if (state == MessageDataAccount.StateType.ChangePassword)
            {
                TextButton.text = "Change";
            }
        }
    }
}
