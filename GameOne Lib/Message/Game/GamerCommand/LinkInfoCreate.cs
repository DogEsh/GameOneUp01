using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Message
{
    public class LinkInfoCreate
    {
        private ISimplusInfo _source;
        private ISimplusInfo _destination;
        public ISimplusInfo Source
        {
            get
            {
                return _source;
            }
        }
        public ISimplusInfo Destination
        {
            get
            {
                return _destination;
            }
        }
        public LinkInfoCreate(ISimplusInfo source, ISimplusInfo destination)
        {
            _source = source;
            _destination = destination;
        }
    }
}
