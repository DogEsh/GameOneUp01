using SimpleTeam.GameOne.Message;
using SimpleTeam.Message;
using SimpleTeam.GameOne.Data;
using SimpleTeam.User;
using System;
using SimpleTeam.Command;
using SimpleTeam.GameOne.Command;
using SimpleTeam.Command.Scenario;

namespace SimpleTeam.GameOne.Scene
{
    class SceneServerMenuMessages : SceneMessages
    {
        public SceneServerMenuMessages(IScenario scenario)
        {
            base.Add(new MessageHandlerServerAccount(scenario));
            base.Add(new MessageHandlerServerChat(scenario));
        }

    }
}
