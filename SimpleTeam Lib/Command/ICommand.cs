using SimpleTeam.Parameter;
using System;

namespace SimpleTeam.Command
{
    using ParameterID = Byte;
    /**
    <summary>
    Команда исполняющая сценарную операцию.
    </summary>
    */
    public interface ICommand
    {
        ParameterID DestinationType { get; }
        void Do(IAllParameters parameter);
    }
}
