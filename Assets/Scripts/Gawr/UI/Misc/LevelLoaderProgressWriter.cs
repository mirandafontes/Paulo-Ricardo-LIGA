using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Gawr.UI.Misc
{
    //Esta classe poderia está melhor escrita.
    //A maneira do check e do tratamento estão muito simples e não fornecem
    //a flexibilidade adequada. Um UnityEvent com a capacidade de
    //return value seria adequado para cá.
    public class LevelLoaderProgressWriter : MonoBehaviour
    {
        [Header("Unity Events")]
        [SerializeField] private AssociateLevelLoader _associateLevelLoader;
        [SerializeField] private UnityEvent _endProgressMethod;

        [Header("UI")]
        [SerializeField] private Slider _progressBar;

        private void Start()
        {
            StartCoroutine(CheckRoutine());
        }

        private IEnumerator CheckRoutine()
        {
            //Evitar criar um novo a cada iteração
            var wait = new WaitForSeconds(0.1f);

            //Ao evitar o loading automatico da cena com:
            //_asyncSceneOperation.allowSceneActivation = false;
            //o progress value para em 0.9.
            while (_associateLevelLoader.Progress() < 0.89f)
            {
                _progressBar.value = _associateLevelLoader.Progress();
                yield return wait;
            }

            _endProgressMethod.Invoke();

            yield return null;
        }
    }
}