using SimpleTeam.Message;
using SimpleTeam.Command;
using System;
using SimpleTeam.GameOne.Parameter;
using SimpleTeam.Parameter;

namespace SimpleTeam.GameOne.Command
{
    using ParameterID = Byte;
    /**
    <summary>
    Команда для обработки сообщения из интернета.
    </summary>
    */
    public class CommandSendMessageScene : ICommand
    {
        public ParameterID DestinationType
        {
            get
            {
                return _message.ParameterType;
            }
        }

        private IMessage _message;

        public CommandSendMessageScene(IMessage message)
        {
            _message = message;
        }

        

        void ICommand.Do(IAllParameters parameter)
        {
            IParameter p = parameter.GetParameter(DestinationType);
            if (p != null)
            {
                IParameterSceneMessages pp = p as IParameterSceneMessages;
                pp.GetSceneMessages().SetMessage(_message);
            }
        }
    }
}