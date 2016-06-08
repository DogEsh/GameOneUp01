using SimpleTeam.GameOne.Scene;
using SimpleTeam.GameOne.Message.Manager;
using System;

namespace SimpleTeam.GameOne.Parameter
{
    using SimpleTeam.Command.Scenario;
    using ParameterID = Byte;
    public class ParameterMessagesManager : IParameterMessagesManager
    {
        public ParameterID Type
        {
            get
            {
                return (ParameterID)HelperParameterID.MessageManager;
            }
        }
        IMessagesManagerScenario _manager;
        public ParameterMessagesManager(IMessagesManager manager)
        {
            _manager = manager;
        }
        public IMessagesManagerScenario GetMessagesManager()
        {
            return _manager;
        }

        public IScenario GetScenario()
        {
            return _manager.GetScenario();
        }
    }
}
