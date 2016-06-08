using System.IO;
using System;
using System.Runtime.Serialization;
using SimpleTeam.Message;
using SimpleTeam.Network;
using System.Runtime.Serialization.Formatters.Binary;

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
