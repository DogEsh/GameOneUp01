using SimpleTeam.GameOne.Scene;
using SimpleTeam.Command.Scenario;
using System.Collections.Generic;
using SimpleTeam.GameOne.Message.Manager;
using SimpleTeam.Command;
using System;
using SimpleTeam.Main;
using SimpleTeam.Parameter;

namespace SimpleTeam.GameOne.Parameter
{
    /**
    <summary> 
    Хранит все необходимые параметры для исполнения команд.
    </summary>
    */
    public class AllGameOneParameters : AllParameters
    {
        public AllGameOneParameters(IMain main, ISceneMenu sceneMenu, ISceneGame sceneGame, IMessagesManager messagesManager) : base()
        {
            _parameter.Add(new ParameterMain(main));
            _parameter.Add(new ParameterSceneMenu(sceneMenu));
            _parameter.Add(new ParameterSceneGame(sceneGame));
            _parameter.Add(new ParameterMessagesManager(messagesManager));
        }


    }
}
