using System;
using System.Collections.Generic;
using SimpleTeam.Command.Scenario;

namespace SimpleTeam.Command
{
    using TypeID = Byte;
    public class AllParameters : IAllParameters
    {
        protected List<IParameter> _parameter;
        protected AllParameters()
        {
            _parameter = new List<IParameter>();
        }
        public AllParameters(List<IParameter> parameter)
        {
            _parameter = parameter;
        }
        public List<IScenario> GetAllScenario()
        {
            List<IScenario> scenarios = new List<IScenario>();
            foreach (IParameter p in _parameter)
            {
                IScenario s = p.GetScenario();
                if (s != null)
                {
                    scenarios.Add(s);
                }
            }
            return scenarios;
        }
        public IParameter GetParameter(TypeID ID)
        {
            foreach (IParameter p in _parameter)
            {
                if (p.Type == ID)
                {
                    return p;
                }
            }
            return null;
        }
    }
}
