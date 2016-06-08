using SimpleTeam.Message;
using SimpleTeam.Command;
using System;

namespace SimpleTeam.GameOne.Command
{
    using TypeID = Byte;
    /**
    <summary>
    Команда для обработки сообщения из интернета.
    </summary>
    */
    public class CommandProcessMessageSmart : ICommand
    {
        public TypeID Type
        {
            get
            {
                if (_command == null)
                    return (TypeID)HelperParameterID.None;
                return _command.GetParameterType();
            }
        }

        ICommandProcessMessage _command;
        private IMessage _message;

        

        public CommandProcessMessageSmart(RegisterCommandProcessMessage register, IMessage message)
        {
            
            _message = message;
            _command = register.Find(_message.Type);
        }

        void ICommand.Do(IAllParameters parameter)
        {
            IParameter p = parameter.GetParameter(Type);
            if (p != null)
            {
                _command.Do(p, _message);
            }
        }
    }
}
