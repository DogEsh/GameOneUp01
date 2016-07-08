using SimpleTeam.Threading;
using System.Threading;

namespace SimpleTeam.GameOne.Main
{

    /**
    <summary> 
    Запускает сервер.
    </summary>
    */
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();
        }
    }
}
