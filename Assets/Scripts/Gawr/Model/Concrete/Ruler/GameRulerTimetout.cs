using Gawr.Model.Data;
using Gawr.Model.Interface.Rulers;
using UnityEngine;

namespace Gawr.Model.Ruler
{
    public class GameRulerTimetout : GameRuler
    {
        [SerializeField] private GameObject _itimer;
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private PlayerContainerData _playerData;
        private ITimer _timer;

        private void Awake()
        {
            _timer = _itimer.GetComponent<ITimer>();
        }

        public override bool WinCondition()
        {
            if (_timer.CurrentTime() < _sceneData.TotalTime)
            {
                if (_playerData.CurrentPoints >= _sceneData.PointsToWin)
                {
                    return true;
                }
            }

            return false;
        }
        public override bool LoseCondition()
        {
            if (_timer.CurrentTime() >= _sceneData.TotalTime && _playerData.CurrentPoints < _sceneData.PointsToWin)
            {
                return true;
            }

            if (!_playerData.IsPlayerAlive)
            {
                return true;
            }

            return false;
        }
    }
}
