namespace Gawr.Model.Interface.LevelLoader
{
    public interface ILevelLoader
    {
        void LoadNextLevel();
        void LoadLevel(int index);
        void LoadLevel(string sceneName);
        void LoadMainMenu();
    }
}