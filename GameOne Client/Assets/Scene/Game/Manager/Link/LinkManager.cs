using SimpleTeam.Message;
using SimpleTeam.GameOne.Message;
using SimpleTeam.Command.Scenario;
using SimpleTeam.Command;
using SimpleTeam.GameOne.Command;
using System;

namespace SimpleTeam.GameOne.Scene
{
    class LinkManager : ILinkManager
    {
        private ILinkManager _creator;
        private ILinkManager _destroyer;
        public LinkManager(IScenario scenario)
        {
            _creator = new LinkManagerCreator(scenario);
            _destroyer = new LinkManagerDestroyer(scenario);
        }

        public void SetMouse(IMouseManager mouse)
        {
            _creator.SetMouse(mouse);
            _destroyer.SetMouse(mouse);
        }
    }
}
