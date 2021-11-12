namespace Model.Interface.LevelLoader
{
    public interface ISyncLevelLoader
    {
        void LoadNextLevel();
        void LoadLevel(int index);
        void LoadLevel(string sceneName);
        void LoadMainMenu();
    }
}