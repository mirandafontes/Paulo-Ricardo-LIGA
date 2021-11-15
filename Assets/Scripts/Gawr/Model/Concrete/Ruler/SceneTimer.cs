using System.Collections;
using Gawr.Model.Data;
using Gawr.Model.Interface.Rulers;
using UnityEngine;
using UnityEngine.Events;

namespace Gawr.Model.Ruler
{
    public class SceneTimer : MonoBehaviour, ITimer
    {
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private UnityEvent _timeoutEvent;
        [SerializeField] [Tooltip("Evento para cada contagem no timer")] private UnityEvent _cicleEvent;
        private int _currentTime;
        private bool _resumeCount;
        private bool _alreadyCounting;

        private void Awake()
        {
            _currentTime = 0;

            _alreadyCounting = false;
            _resumeCount = false;
        }

        public void StartTimer()
        {
            _resumeCount = true;

            if (!_alreadyCounting)
            {
                StartCoroutine(CountTime());
            }

        }
        public void StopTimer()
        {
            _resumeCount = false;
        }
        public void TimeOut()
        {
            _timeoutEvent.Invoke();
        }
        public int CurrentTime()
        {
            return _currentTime;
        }

        private IEnumerator CountTime()
        {
            var wait = new WaitForSeconds(1f);
            _alreadyCounting = true;

            while (_currentTime < _sceneData.TotalTime)
            {
                yield return wait;

                if (_resumeCount)
                {
                    _currentTime++;
                }

                _cicleEvent?.Invoke();
            }

            TimeOut();

            yield return null;
        }
    }
}
