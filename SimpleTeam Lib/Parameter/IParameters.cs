using SimpleTeam.Command.Scenario;

namespace SimpleTeam.Parameter
{
    public interface IParameter : IParameterID
    {
        IScenario GetScenario();
    }
}
