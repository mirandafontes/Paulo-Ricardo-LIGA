namespace Gawr.Model.Interface.LevelLoader
{
    public interface ILevelLoader
    {
        bool Loading { get; }
        float Progress { get; }
        void ActivateNextLevel();
        void LoadLevel(int index);
        void ReloadLevel();
        void LoadMainMenu();
    }
}