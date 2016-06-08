using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    public class MessageLinkOld
    { 
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
        public MessageLinkOld(LinkLogicsOld link)
        {
            _source = link.Source;
            _destination = link.Destination;
        }
    }
}
