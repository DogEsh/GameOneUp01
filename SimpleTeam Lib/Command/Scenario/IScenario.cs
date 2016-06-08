

namespace SimpleTeam.Command.Scenario
{
    public interface IScenario
    {
        ICommand Get();
        void Set(ICommand command);
    }
}