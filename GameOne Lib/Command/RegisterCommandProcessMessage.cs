using System;
using System.Collections.Generic;
using System.Reflection;

namespace SimpleTeam.GameOne.Command
{
    using TypeID = Byte;
    /**
    <summary>
    Реестр всех команд обрабатывающих сообщения из интернета.
    </summary>
    */
    public class RegisterCommandProcessMessage
    {
        private Dictionary<TypeID, ICommandProcessMessage> _dictionary;

        public RegisterCommandProcessMessage()
        {
            _dictionary = GetDictionary();
        }
        
        private Dictionary<TypeID, ICommandProcessMessage> GetDictionary()
        {
            var assemblyType = typeof(RegisterCommandProcessMessage);

            var packers = new Dictionary<TypeID, ICommandProcessMessage>();
            foreach (var type in assemblyType.Assembly.GetTypes())
            {
                if (!type.IsClass)
                    continue;

                if (type.IsAbstract)
                    continue;


                if (typeof(ICommandProcessMessage).IsAssignableFrom(type))
                {
                    ICommandProcessMessage p = Activator.CreateInstance(type) as ICommandProcessMessage;
                    packers.Add(p.Type, p);
                }

            }

            return packers;
        }
        public ICommandProcessMessage Find(TypeID type)
        {
            if (_dictionary.ContainsKey(type))
                return _dictionary[type];
            return null;
        }
    }
}
