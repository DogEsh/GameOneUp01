using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.Parameter
{
    using ParameterID = Byte;
    public interface IParameterID
    {
        ParameterID Type { get; }
    }
}
