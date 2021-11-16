using Gawr.Model.Data;
using Gawr.Model.Interface.Rulers;
using UnityEngine;

namespace Gawr.Model.Ruler
{
    /// <summary>
    /// Regras padrão: Obter acima de tantos pontos, ficar vivo e o tempo não acabar antes.
    /// </summary>
    public class DefaultRulesCheck : GameRuler
    {
        [SerializeField] private GameObject _itimer;
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private PlayerContainerData _playerData;
        private ITimer _timer;

        private void Awake()
        {
            _timer = _itimer.GetComponent<ITimer>();
        }

        //Essas outras condições (pontos e morreu) poderiam ser
        //outros scripts menores do GameRuler.
        //Assim, cada scene seria formado por uma lista
        //de condições de jogo, possibilitando
        //condições mais complexas de uma maneira simples.
        //Entretanto, nesse ponto, não há complexidade suficiente
        //para essa separação de classes.
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
