using System;
using UnityEngine;

namespace SimpleTeam.GameOne.GameInfo
{
    using GameID = UInt16;
    public class SimplusInfo : ISimplusInfo
    {
        private ILinkInfoContainer _links;
        private Circle _obj2D;
        private ISimplusHP _hp;
        private IParty _party;
        private GameID _id;
        public IParty Party { get { return _party; } }
        public ISimplusHP HP { get { return _hp; } }
        public Circle Obj2D { get { return _obj2D; } }
        public ILinkInfoContainer Links { get { return _links; } }

        public GameID ID
        {
            get
            {
                return _id;
            }
        }

        public SimplusInfo(GameID id, Circle circle, ISimplusHP hp, IParty party, ILinkInfoContainer links)
        {
            _id = id;
            _obj2D = circle;
            _hp = hp;
            _party = party;
            _links = links;

        }

        public void SetInfo(ISimplusInfo info)
        {
            _id = info.ID;
            _hp = info.HP;
            _party = info.Party;
            _obj2D = info.Obj2D;
            //? reference
            _links = info.Links;
        }

        void ISimplusInfoServer.IncHP(int HP, ISimplusInfo source)
        {
            if (!_party.IsMy(source.Party))
            {
                bool isСaptured = _hp.Attack(HP);
                if (isСaptured)
                    _party.ID = source.Party.ID;
            }
            else
            {
                _hp.Defense(HP);
            }
        }

        void ISimplusInfoClient.IncHP(int HP, ISimplusInfo source)
        {
            if (!_party.IsMy(source.Party))
                HP *= -1;
            _hp.Inc(HP);
        }
    }
}
