using System.Collections.Generic;
using System.Threading;
using SimpleTeam.SystemBase;
using SimpleTeam.Parameter;

namespace SimpleTeam.Command.Scenario
{

    /**
    *<summary>
    Исполняет сценарии, вызывая по очереди команды.
    <para/>
    Для того чтобы он исполнял сценарий, ему надо его добавить.
    <para/>
    Хранит все необходимые параметры для исполнения команд.
    </summary>
    */
    public class ScenarioMachine : StateMachine
    {
        IAllParameters _parameters;
        List<IScenario> _scenarios;
        public ScenarioMachine(IAllParameters parameters)
        {
            _parameters = parameters;
            _scenarios = _parameters.GetAllScenario();
        }


        protected override bool Init()
        {
            return true;
        }
        protected override void Deinit()
        {
            _scenarios = null;
        }

        protected override bool DoAnything()
        {
            Thread.Sleep(100);
            foreach (IScenario s in _scenarios)
            {
                while (true)
                {
                    ICommand c = s.Get();
                    if (c == null) break;
                    c.Do(_parameters);
                }
            }
            
            return true;
        }
    }
}
