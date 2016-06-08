using SimpleTeam.Main;

namespace SimpleTeam.Command
{
    public interface IParamaterMain : IParameter
    {
        IMain GetMain();
    }
}
