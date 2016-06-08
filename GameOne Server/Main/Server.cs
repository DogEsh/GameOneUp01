using System.Threading;
using SimpleTeam.GameOne.Network;
using SimpleTeam.GameOne.SystemBase;
using SimpleTeam.Command.Scenario;
using SimpleTeam.Parameter;
using SimpleTeam.GameOne.Parameter;
using SimpleTeam.GameOne.Message.Manager;
using SimpleTeam.GameOne.Scene;
using SimpleTeam.Main;


namespace SimpleTeam.GameOne.Main
{
    /**
    <summary> 
    Управление сервером.
    </summary>
    */
    sealed class Server : IMain
    {
        MessagesManager _messagesManager;
        SceneServerMenu _sceneMenu;
        SceneServerGame _sceneGame;
        NetworkServerMachine _network;
        ScenarioMachine _scenario;
        private bool _isExit;
        ConsoleCtrl cc;
        public Server()
        {
            _isExit = false;
            _sceneMenu = new SceneServerMenu();
            _sceneGame = new SceneServerGame();
            _messagesManager = new MessagesManager();
            _network = new NetworkServerMachine(_messagesManager);
            cc = new ConsoleCtrl();
            IAllParameters p = new AllGameOneParameters(this, _sceneMenu, _sceneGame, _messagesManager);
            _scenario = new ScenarioMachine(p);
        }
        public void Start()
        {
            cc.ControlEvent += new ConsoleCtrl.ControlEventHandler(this.Close);
            Go();
        }
        private void Close(ConsoleCtrl.ConsoleEvent consoleEvent)
        {
            if (consoleEvent == ConsoleCtrl.ConsoleEvent.CtrlClose)
            {
                Close();
                System.Environment.Exit(-1);
            }
        }
        private void Close()
        {
            _network.Stop();
            _scenario.Stop();
            _network.Close();
            _scenario.Close();
            _network = null;
        }
        private void Go()
        {
            _network.Start();
            _scenario.Start();
            while (true)
            {
                Thread.Sleep(100);
                if (_isExit) break;
            }
            Close();
        }

        public void Exit()
        {
            _isExit = true;
        }
    }
}

