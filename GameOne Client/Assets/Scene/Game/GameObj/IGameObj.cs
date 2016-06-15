using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    interface IGameObj<T> : IGameObjID
    {
        T GetInfo();

    }
}
