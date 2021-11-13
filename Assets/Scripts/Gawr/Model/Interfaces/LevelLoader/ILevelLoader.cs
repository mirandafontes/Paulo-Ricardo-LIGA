namespace Gawr.Model.Interface.LevelLoader
{
    public interface ILevelLoader
    {
        float Progress { get; }
        void ActivateNextLevel();
        void LoadLevel(int index);
        void ReloadLevel();
        void LoadMainMenu();
    }
}