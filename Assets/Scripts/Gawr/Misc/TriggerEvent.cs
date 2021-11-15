using UnityEngine;
using UnityEngine.Events;

namespace Gawr.Misc
{
    public class TriggerEvent : MonoBehaviour
    {
        [Header("Target")]
        [SerializeField] private Collider2D _targetCollider;

        [Header("Callback")]
        [SerializeField] private UnityEvent _onTriggerEnter;
        [SerializeField] private UnityEvent _onTriggerStay;
        [SerializeField] private UnityEvent _onTriggerExit;

        private void Awake()
        {
            if (_targetCollider == null)
            {
                Debug.LogError($"Target collider : {_targetCollider}.");
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (!CheckEquality(other))
            {
                return;
            }

            _onTriggerEnter.Invoke();
        }

        public void OnTriggerStay2D(Collider2D other)
        {
            if (!CheckEquality(other))
            {
                return;
            }

            _onTriggerStay.Invoke();
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (!CheckEquality(other))
            {
                return;
            }

            _onTriggerExit.Invoke();
        }

        private bool CheckEquality(Collider2D other)
        {
            //Com certeza há uma forma melhor de escrever isso
            if (other.Equals(_targetCollider))
            {
                return true;
            }

            return false;
        }
    }
}