using SimpleTeam.Command;
using SimpleTeam.Main;
using SimpleTeam.Command.Scenario;
using System;

namespace SimpleTeam.GameOne.Command
{
    using TypeID = Byte;
    public class ParameterMain : IParamaterMain
    {
        public TypeID Type
        {
            get
            {
                return (TypeID)HelperParameterID.Main;
            }
        }

        private IMain _main;
        public ParameterMain(IMain main)
        {
            _main = main;
        }
        public IScenario GetScenario()
        {
            return null;
        }
        public IMain GetMain()
        {
            return _main;
        }
    }
}
