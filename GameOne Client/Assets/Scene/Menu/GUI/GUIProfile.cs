using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTeam.Message;
using SimpleTeam.User;
using SimpleTeam.GameOne.Message;

namespace SimpleTeam.GameOne.Scene
{
    using MessageID = Byte;
    public class GUIProfile : MonoBehaviour, IMessageHandler
    {
        public GameObject ObjNick;
        public GameObject ObjHonor;
        public Text TextNick;
        public Text TextHonor;

        public IMessageContainer _container = new MessageContainer();

        private IUserProfile _profile;

        public byte Type
        {
            get
            {
                return (MessageID)HelperMessageID.Profile;
            }
        }

        public void SetMessage(IMessage message)
        {
            _container.Set(message);
        }

        void Update()
        {
            if (!_container.IsEmpty)
            {
                MessageDataProfile m = _container.Get() as IMessageData as MessageDataProfile;
                IUserProfile p = new UserProfile();
                p.Nick = m.Nick;
                UpdateProfile(p);
            }
        }

        public void SetStateSignIn(bool isSignIn)
        {
            if (isSignIn)
            {
                SetOnState();
            }
            else
            {
                SetOffState();
            }
        }

        public void UpdateProfile(IUserProfile profile)
        {
            if (profile != null)
            {
                _profile = profile; _profile = profile;
            }
            TextNick.text = _profile.Nick;
        }
        
        private void SetOnState()
        {
            ObjNick.SetActive(true);
        }
        private void SetOffState()
        {
            ObjNick.SetActive(false);
            TextNick.text = string.Empty;
        }

       
    }
}
