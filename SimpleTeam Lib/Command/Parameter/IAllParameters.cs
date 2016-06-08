using System.Collections.Generic;
using SimpleTeam.Command.Scenario;
using SimpleTeam.Command;
using System;

namespace SimpleTeam.Command
{
    using TypeID = Byte;
    public interface IAllParameters
    {
        List<IScenario> GetAllScenario();
        IParameter GetParameter(TypeID ID);
    }
}
