using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    public class LinkLogicsOld
    {
        private SimplusOld _focus;
        private SimplusOld _source;
        private SimplusOld _destination;
        public SimplusOld Source
        {
            get
            {
                return _source;
            }
        }
        public SimplusOld Destination
        {
            get
            {
                return _destination;
            }
        }
        public SimplusOld Focus
        {
            get
            {
                return _focus;
            }
        }
        public bool ToDraw
        {
            get
            {
                return (_source != null && _focus != _source);
            }
        }

        private MessageLinkOld _message;

        public MessageLinkOld GetMessage()
        {
            MessageLinkOld m = _message;
            _message = null;
            return m;
        }

        private void Clear()
        {
            if (_source != null)
            {
                _source._wrapper.SetPressed(false);
                _source = null;
            }
            
            _destination = null;
            //SetAnimation(_focus, SimplusActionState.Focused);
        }

        public void SetMouseState(HelperMouseState state)
        {
            if (HelperMouseState.Down == state)
            {
                Clear();
                if (_focus != null)
                {
                    _source = _focus;
                    _source._wrapper.SetPressed(true);
                }
            }
            if (HelperMouseState.Up == state)
            {
                if(_source != null && _focus != null && _focus != _source)
                {
                    _destination = _focus;
                    _message = new MessageLinkOld(this);
                }
                Clear();
            }
        }

        public void SetFocus(SimplusOld focus)
        {
            if (focus != _focus)
            {
                if (focus != null)
                {
                    focus._wrapper.SetFocused(true);
                }
                if (_focus != null)
                {
                    _focus._wrapper.SetFocused(false);
                }
                _focus = focus;
            }
        }

      
    }
}
