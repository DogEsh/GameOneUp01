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
    Команда для отправки сообщения в интернет.
    </summary>
    */
    public class CommandSendMessageNetwork : ICommand
    {
        public ParameterID DestinationType
        {
            get
            {
                return (ParameterID)HelperParameterID.MessageManager;
            }
        }

        IMessage _message;
        public CommandSendMessageNetwork(IMessage message)
        {
            _message = message;
        }

        void ICommand.Do(IAllParameters parameters)
        {
            IParameterMessagesManager p = parameters.GetParameter(DestinationType) as IParameterMessagesManager;
            if (p != null)
            {
                p.GetMessagesManager().SetMessage(_message);
            }
            
        }
    }
}
