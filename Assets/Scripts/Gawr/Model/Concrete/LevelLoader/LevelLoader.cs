using System.Threading.Tasks;
using Gawr.Model.Interface.LevelLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gawr.Model.Concrete.LevelLoader
{
    public class LevelLoader : MonoBehaviour, ILevelLoader
    {
        public static ILevelLoader Instance
        {
            get
            {
                return _instance;
            }
        }
        private static LevelLoader _instance;
        public float Progress
        {
            get
            {
                return _progress;
            }
        }
        private float _progress;
        private AsyncOperation _asyncSceneOperation;
        private bool _loading;
        public bool Loading
        {
            get
            {
                return _loading;
            }
        }

        private void Awake()
        {
            InitializeSingleton();

            _progress = 0f;
            _loading = false;
        }

        private void InitializeSingleton()
        {
            if (LevelLoader.Instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        /// <summary>
        /// Método para ativamento da cena. Utilizado no inspector.
        /// </summary>
        public void ActivateNextLevel()
        {
            if (_loading)
            {
                _instance._asyncSceneOperation.allowSceneActivation = true;
                _loading = false;
            }
        }

        public void LoadLevel(int index)
        {
            if (_loading)
            {
#if UNITY_EDITOR
                Debug.LogError("Already loading something async.");
#endif
                return;
            }

            if (index < 0 || index > SceneManager.sceneCountInBuildSettings)
            {
#if UNITY_EDITOR
                Debug.LogError($"Index out of range. Scene Count in build settings : {SceneManager.sceneCountInBuildSettings}");
#endif
                return;
            }

            switch (index)
            {
                case 0:
                    {
#if UNITY_EDITOR
                        Debug.Log("Main Menu Index. Loading Main Menu.");
#endif
                        LoadMainMenu();
                        break;
                    }

                case 1:
                    {
#if UNITY_EDITOR
                        Debug.Log("Intermediare index. Doing nothing.");
#endif
                        break;
                    }

                default:
                    {
                        AsyncLoadLevel(index);
                        break;
                    }
            }
        }

        public void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadMainMenu()
        {
            //Scene at index[0] == MainMenu
            SceneManager.LoadScene(0);
        }

        private async void AsyncLoadLevel(int index)
        {
            //Scene at index[1] == Intermediare
            SceneManager.LoadScene(1);

            _loading = true;

            await Task.Delay(2000);

            _instance._asyncSceneOperation = SceneManager.LoadSceneAsync(index);
            _instance._asyncSceneOperation.allowSceneActivation = false;

            do
            {
                await Task.Delay(100);
                _progress = _asyncSceneOperation.progress;
            } while (_asyncSceneOperation.progress < 0.9f);
        }
    }
}