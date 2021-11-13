using UnityEngine;
using UnityEngine.Events;

namespace Gawr.Misc
{
    public class CollisionEvent : MonoBehaviour
    {
        [Header("Target")]
        [SerializeField] private Collider2D _initialCollider;
        [SerializeField] private Collider2D _otherCollider;
        
        [Header("Callback")]
        [SerializeField] private UnityEvent _onCollisionEnter;
        [SerializeField] private UnityEvent _onCollisionStay;
        [SerializeField] private UnityEvent _onCollisionExit;

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (!CheckEquality(collision))
            {
                return;
            }

            _onCollisionEnter.Invoke();
        }

        public void OnCollisionStay2D(Collision2D collision)
        {
            if (!CheckEquality(collision))
            {
                return;
            }

            _onCollisionStay.Invoke();
        }

        public void OnCollisionExit2D(Collision2D collision)
        {
            if (!CheckEquality(collision))
            {
                return;
            }

            _onCollisionExit.Invoke();
        }

        private bool CheckEquality(Collision2D collision)
        {
            if (collision.collider.Equals(_initialCollider) && collision.otherCollider.Equals(_otherCollider))
            {
                return true;
            }

            return false;
        }
    }
}