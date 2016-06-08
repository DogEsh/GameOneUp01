using System.IO;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SimpleTeam.Message;
using System.Runtime.Serialization.Formatters.Binary;
using SimpleTeam.Network;
using SimpleTeam.User;

namespace SimpleTeam.BinarySerialization.DotNet
{


    public class Unpacker:IUnpacker
    {
        IFormatter formatter;
        public Unpacker()
        {
            formatter = new BinaryFormatter();
        }


        public UnpackerState CreateMessageData(ref IMessageData message, Packet packet)
        {
            if (!packet.IsReady) return UnpackerState.NotReady;
            message = null;
            using (MemoryStream stream = new MemoryStream(packet.GetData()))
            {
                try
                {
                    message = formatter.Deserialize(stream) as IMessageData;
                }
                catch (Exception ex)
                {
                    message = null;
                    return UnpackerState.NotParse;
                }
            }
            return UnpackerState.Ok;
            
        }
    }
}
