using UnityEngine;
using UnityEngine.Events;

namespace Gawr.Model.Interface.Rulers
{
    /// <summary>
    /// Classe abstrata com template method para implementação
    /// das regras do game. Possui eventos do Unity para
    /// Win e Lose. Assim, é possível possuir
    /// diversas outras regras, sendo possível inclusive criar uma
    /// regra para cada fase.
    /// </summary>
    public abstract class GameRuler : MonoBehaviour, IGameConditioner
    {
        [SerializeField] private UnityEvent _winEvent;
        [SerializeField] private UnityEvent _loseEvent;
        public void Win()
        {
            if (CheckWinCondition())
            {
                _winEvent?.Invoke();
            }
        }
        public bool CheckWinCondition()
        {
            return WinCondition();
        }
        public abstract bool WinCondition();
        public void Lose()
        {
            if (CheckLoseCondition())
            {
                _loseEvent?.Invoke();
            }
        }
        public bool CheckLoseCondition()
        {
            return LoseCondition();
        }
        public abstract bool LoseCondition();

        [ContextMenu("GameOver Check")]
        public void CheckGameOver()
        {
            Win();
            Lose();
        }
    }
}
