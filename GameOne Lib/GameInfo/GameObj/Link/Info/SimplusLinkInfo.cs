using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.GameOne.GameInfo
{
    using GameID = UInt16;
    public class SimplusLinkInfo : ISimplusLinkInfo
    {
        private GameID _id;

        private SimplusInfo _source;
        private SimplusInfo _destination;

        private IObj2D _current;
        private IObj2D _lost;

        private SimplusLinkActionState _state;


        public SimplusInfo Source
        {
            get
            {
                return _source;
            }

            set
            {
                _source = value;
            }
        }

        public SimplusInfo Destination
        {
            get
            {
                return _destination;
            }

            set
            {
                _destination = value;
            }
        }

        public IObj2D Current
        {
            get
            {
                return _current;
            }

            set
            {
                _current = value;
            }
        }

        public IObj2D Lost
        {
            get
            {
                return _lost;
            }

            set
            {
                _lost = value;
            }
        }

        public SimplusLinkActionState State
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
            }
        }

        public GameID ID
        {
            get
            {
                return _id;
            }
        }
    }
}
