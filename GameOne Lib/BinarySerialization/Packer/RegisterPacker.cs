using System;
using System.Collections.Generic;
using System.Reflection;

namespace SimpleTeam.GameOne.BinarySerialization
{
    
    using MessageID = Byte;
    /**
    <summary> 
    Реестр всех упаковщиков сообщений.
    </summary>
    */
    public class RegisterPacker
    {

        private Dictionary<MessageID, IPackerMessage> _dictionary;
        public RegisterPacker()
        {
            _dictionary = GetDictionary();
        }
        private Dictionary<MessageID, IPackerMessage> GetDictionary()
        {
            var assemblyType = typeof(Assembly);

            var packers = new Dictionary<MessageID, IPackerMessage>();
            foreach (var type in assemblyType.Assembly.GetTypes())
            {
                if (!type.IsClass)
                    continue;

                if (type.IsAbstract)
                    continue;


                if (typeof(IPackerMessage).IsAssignableFrom(type))
                {
                    IPackerMessage p = Activator.CreateInstance(type) as IPackerMessage;
                    packers.Add(p.Type, p);
                }
                    
            }

            return packers;
        }
        public IPackerMessage  Find(MessageID type)
        {
            if (_dictionary.ContainsKey(type))
                return _dictionary[type];
            return null;
        }
    }
}
