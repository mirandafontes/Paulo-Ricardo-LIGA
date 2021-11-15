using Gawr.Model.Concrete;
using Gawr.Model.Concrete.LevelLoader;
using Gawr.Model.Interface.LevelLoader;
using UnityEngine;

namespace Gawr.UI.Misc
{
    /// <summary>
    /// Classe utilizada pela UI basicamente. Associando dos métodos
    /// do LevelLoader (que é um singleton) aos botões usando
    /// essa classe intermediária.
    /// </summary>
    public class AssociateLevelLoader : MonoBehaviour
    {
        private ILevelLoader _levelLoader;

        private void Awake()
        {
            _levelLoader = FindObjectOfType<LevelLoader>();
        }

        public void LoadLevel(int index)
        {
            _levelLoader?.LoadLevel(index);
        }

        public void LoadMainMenu()
        {
            _levelLoader?.LoadMainMenu();
        }

        public void ActivateNextLevel()
        {
            ((LevelLoader)_levelLoader)?.ActivateNextLevel();
        }

        public float Progress()
        {
            //Evitar uso de nullable para tipos simples
            if (_levelLoader != null)
            {
                return _levelLoader.Progress;
            }
            else
            {
                return -1;
            }
        }

        public bool IsLoading()
        {
            //Evitar uso de nullable para tipos simples
            if (_levelLoader != null)
            {
                return _levelLoader.Loading;
            }
            else
            {
                return false;
            }
        }
    }
}
