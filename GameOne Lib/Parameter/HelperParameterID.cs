using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.GameOne.Parameter
{
    using ParameterID = Byte;
    /**
    <summary> 
    Реестр всех типов сообщений.
    </summary>
    */
    public enum HelperParameterID : ParameterID
    {
        None,
        Main,
        MessageManager,
        SceneMenu,
        SceneGame
    }
}
