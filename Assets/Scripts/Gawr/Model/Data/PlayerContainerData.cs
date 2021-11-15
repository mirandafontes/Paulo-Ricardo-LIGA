using UnityEngine;

namespace Gawr.Model.Data
{
    [DisallowMultipleComponent]
    /// <summary>
    /// Classe que atua como facade para classes monobehaviour
    /// e os dados. Utiliza o SceneData para gerenciamento
    /// a pontuação dos cogumelos.
    /// </summary>
    public class PlayerContainerData : MonoBehaviour
    {
        /// Esta classe ajudaria a criar
        /// outros modelos de IA (somado ao command), permitindo
        /// representar também os dados dela, usando a mesma
        /// estrutura para o player. Ou seja, poderiamos ter uma
        /// IA como um rato, por exemplo, capaz de pegar os cogumelos
        /// bons antes do jogador e assim, obter seus dados no pós-game.
        private PlayerData _playerData;
        [SerializeField] private SceneData _sceneData;
        public int CurrentPoints
        {
            get
            {
                return _playerData.CurrentPoints;
            }
        }
        public int GoodMushroomsCounter
        {
            get
            {
                return _playerData.GoodMushroomsCounter;
            }
        }
        public bool IsPlayerAlive
        {
            get
            {
                return _playerData.IsPlayerAlive;
            }
        }
        
        private void Awake()
        {
            _playerData = new PlayerData();
            _playerData.IsPlayerAlive = true;
        }

        public void AddPoints(int points)
        {
            if (points < 0)
            {
                return;
            }

            _playerData.AddPoints(points);
        }

        public void RemovePoints(int points)
        {
            if (points > 0)
            {
                return;
            }

            _playerData.RemovePoints(points);
        }

        public void ResetPoints()
        {
            _playerData.ResetPoints();
        }

        public void AddMushroomsAndPoints(int mushrooms)
        {
            if (mushrooms < 0)
            {
                return;
            }

            _playerData.AddGoodMushrooms(mushrooms);
            _playerData.AddPoints(_sceneData.PointsPerGoodMushroom * mushrooms);
        }

        public void RemoveMushroomsAndPoints(int mushrooms)
        {
            if (mushrooms > 0)
            {
                return;
            }

            _playerData.RemoveGoodMushrooms(mushrooms);
            _playerData.RemovePoints(_sceneData.PointsPerGoodMushroom * mushrooms);
        }

        public void ResetMushroomsCounter()
        {
           _playerData.ResetPoints();
        }

        public void PlayerAlive(bool isAlive)
        {
            _playerData.IsPlayerAlive = isAlive;
        }
    }
}
