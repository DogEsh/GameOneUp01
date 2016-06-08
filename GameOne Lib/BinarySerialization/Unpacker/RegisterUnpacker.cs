using System;
using System.Collections.Generic;
using System.Reflection;

namespace SimpleTeam.GameOne.BinarySerialization
{
    using MessageID = Byte;
    /**
    <summary> 
    Реестр всех распаковщиков пакетов.
    </summary>
    */
    public class RegisterUnpacker
    {
        private Dictionary<MessageID, IUnpackerMessage> _dictionary;

        public RegisterUnpacker()
        {
            _dictionary = GetDictionary();
        }
        private Dictionary<MessageID, IUnpackerMessage> GetDictionary()
        {
            var assemblyType = typeof(Assembly);

            var packers = new Dictionary<MessageID, IUnpackerMessage>();
            foreach (var type in assemblyType.Assembly.GetTypes())
            {
                if (!type.IsClass)
                    continue;

                if (type.IsAbstract)
                    continue;


                if (typeof(IUnpackerMessage).IsAssignableFrom(type))
                {
                    IUnpackerMessage p = Activator.CreateInstance(type) as IUnpackerMessage;
                    packers.Add(p.Type, p);
                }

            }

            return packers;
        }
        public IUnpackerMessage Find(MessageID type)
        {
            if (_dictionary.ContainsKey(type))
                return _dictionary[type];
            return null;
        }
    }
}
