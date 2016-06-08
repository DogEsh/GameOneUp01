using System.Collections.Generic;
using SimpleTeam.Command.Scenario;
using SimpleTeam.Command;
using System;

namespace SimpleTeam.Parameter
{
    using ParameterID = Byte;
    public interface IAllParameters
    {
        List<IScenario> GetAllScenario();
        IParameter GetParameter(ParameterID ID);
    }
}
