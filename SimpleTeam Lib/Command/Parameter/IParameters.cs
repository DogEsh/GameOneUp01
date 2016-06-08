using SimpleTeam.Command.Scenario;

namespace SimpleTeam.Command
{
    public interface IParameter : ITypeID
    {
        IScenario GetScenario();
    }
}
