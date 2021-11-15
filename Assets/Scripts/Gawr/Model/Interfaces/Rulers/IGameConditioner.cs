namespace Gawr.Model.Interface.Rulers
{
    /// <summary>
    /// Interface para as condições de vitória e derrota do game.
    /// </summary>
    interface IGameConditioner
    {
        void Win();
        bool WinCondition();
        void Lose();
        bool LoseCondition();
    }
}