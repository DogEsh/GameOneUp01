using System;


namespace SimpleTeam.User
{
    public interface IUserProfile
    {
        String Nick { get; set; }
        bool IsSignIn { get; }
    }
}
