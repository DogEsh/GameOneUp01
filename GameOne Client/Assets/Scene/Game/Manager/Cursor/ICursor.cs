using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    interface ICursor
    {
        IObj2D Source { get; set; }
        IObj2D Destination { get; set; }
        void SetMouse(IMouseManager mouse);
    }
}
