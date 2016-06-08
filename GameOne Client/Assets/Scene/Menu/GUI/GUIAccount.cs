using UnityEngine;
using SimpleTeam.Message;
using SimpleTeam.GameOne.Message;
using System;

namespace SimpleTeam.GameOne.Scene
{
    public class GUIAccount : MonoBehaviour
    {
        public GUISign Sign;
        public Case CaseSign;

        public GameObject ObjSignIn;
        public GameObject ObjSignUp;
        public GameObject ObjSignOut;
        public GameObject ObjChangePassword;

        public void SetStateSignIn(bool isSignIn)
        {
            SetStateAllOff();
            if (isSignIn)
            {
                ObjSignOut.SetActive(true);
                ObjChangePassword.SetActive(true);
            }
            else
            {
                ObjSignIn.SetActive(true);
                ObjSignUp.SetActive(true);
            }
        }

        private void SetStateAllOff()
        {
            ObjSignIn.SetActive(false);
            ObjSignUp.SetActive(false);
            ObjSignOut.SetActive(false);
            ObjChangePassword.SetActive(false);
        }
        private void OpenWindow(MessageDataAccount.StateType state)
        {
            Sign.SetState(state);
            Sign.Clear();
            CaseSign.Open();
        }
        public void OpenSignIn()
        {
            OpenWindow(MessageDataAccount.StateType.SignIn);
        }
        public void OpenSignUp()
        {
            OpenWindow(MessageDataAccount.StateType.SignUp);
        }
        public void OpenSignOut()
        {
            OpenWindow(MessageDataAccount.StateType.SignOut);
        }
        public void OpenChangePassword()
        {
            OpenWindow(MessageDataAccount.StateType.ChangePassword);
        }

    }
}

