using System;


namespace SimpleTeam
{
    using TypeID = Byte;
    /**
    <summary>
    Интерфейс определения ID класса.
    </summary>
    */
    public interface ITypeID
    {
        TypeID Type { get; }
    }
}
