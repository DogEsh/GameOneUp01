using System;


namespace SimpleTeam.GameOne.Message
{
    using MessageID = Byte;
    /**
    <summary> 
    Реестр всех типов сообщений.
    </summary>
    */
    public enum HelperMessageID : MessageID
    {
        Account,
        Chat,
        Profile,
        GameMap,
        GameState,
        GamerCommand
    }
}
