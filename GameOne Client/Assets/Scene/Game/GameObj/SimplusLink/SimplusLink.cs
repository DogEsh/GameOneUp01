using System;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    using GameObjID = UInt16;
    class SimplusLink : GameObjBase, ISimplusLink
    {
        ISimplusLinkInfo _info;
        public override GameObjID ID
        {
            get
            {
                return _info.ID;
            }
        }

        public void UpdateInfo(ISimplusLinkInfo info)
        {
            _info = info;
        }
        public override void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
