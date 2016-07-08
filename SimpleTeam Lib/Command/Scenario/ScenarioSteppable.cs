using System.Collections.Generic;
using System.Threading;
using SimpleTeam.SystemBase;
using SimpleTeam.Parameter;
using SimpleTeam.Threading;
using System;

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
    public class ScenarioSteppable : ISteppable
    {
        IAllParameters _parameters;
        List<IScenario> _scenarios;

        public ScenarioSteppable(IAllParameters parameters)
        {
            _parameters = parameters;
            _scenarios = _parameters.GetAllScenario();
        }

        public bool Step()
        {
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
        public void Destroy()
        { 
        }
    }
}
