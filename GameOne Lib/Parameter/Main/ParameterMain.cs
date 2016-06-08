using SimpleTeam.Parameter;
using SimpleTeam.Main;
using SimpleTeam.Command.Scenario;
using System;

namespace SimpleTeam.GameOne.Parameter
{
    using ParameterID = Byte;
    public class ParameterMain : IParameterMain
    {
        public ParameterID Type
        {
            get
            {
                return (ParameterID)HelperParameterID.Main;
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
