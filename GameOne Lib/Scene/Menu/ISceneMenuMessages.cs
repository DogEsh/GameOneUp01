using SimpleTeam.GameOne.Message;

namespace SimpleTeam.GameOne.Scene
{
    /**
    <summary>
    Интерфейс обработки сообщений меню сценой
    </summary>
    */
    public interface ISceneMenuMessages
    {
        void SetMessage(MessageChat message);
        void SetMessage(MessageAccount message);
        void SetMessage(MessageProfile message);
    }
}
