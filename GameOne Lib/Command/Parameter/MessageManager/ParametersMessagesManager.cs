using SimpleTeam.GameOne.Scene;
using SimpleTeam.GameOne.Message.Manager;
using System;

namespace SimpleTeam.GameOne.Command
{
    using SimpleTeam.Command.Scenario;
    using TypeID = Byte;
    public class ParameterMessagesManager : IParameterMessagesManager
    {
        public TypeID Type
        {
            get
            {
                return (TypeID)HelperParameterID.MessageManager;
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
