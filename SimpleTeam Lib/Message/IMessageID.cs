using System;


namespace SimpleTeam.Message
{
    using MessageID = Byte;
    /**
    <summary>
    Интерфейс определения ID класса.
    </summary>
    */
    public interface IMessageID
    {
        MessageID Type { get; }
    }
}
