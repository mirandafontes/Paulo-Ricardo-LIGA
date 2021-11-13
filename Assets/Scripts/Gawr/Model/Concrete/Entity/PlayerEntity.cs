using Gawr.Misc;
using Gawr.Model.Interface.Entity;
using UnityEngine;

namespace Gawr.Model.Concrete.Entity
{
    /// <summary>
    /// Representa o player e os inimigos (Entities). Ponte entre o command e o monobehaviour.
    /// Receiver. Coloca uma velocidade e indica a direção. Responsável por tratar
    /// a parte de colisões, animação e checks afins.
    /// Ou seja, mover para os lados, para cima e aplicar isso no animator/sprite
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerEntity : MonoBehaviour, IMoveableEntity
    {
        [Header("Data")]
        [SerializeField] private float _runSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _movementSmoothing = 0.05f;

        [Header("Components")]
        [SerializeField] private Animator _animator;
        [SerializeField] private GroundCheck _groundCheck;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private float _horizontalMove;
        private Vector2 _velocityVector;

        private void Start()
        {
            _horizontalMove = 0;
            _velocityVector = Vector2.zero;

            Down();
        }

        public void Up()
        {
            if (!_groundCheck.IsGrounded())
            {
                return;
            }

            _rigidbody.AddForce(Vector2.up * _jumpForce);
            _animator.SetBool(Words.AnimatorIsJumpingHash, true);
        }

        public void Down()
        {
            _animator.SetBool(Words.AnimatorIsJumpingHash, false);
        }

        public void Left()
        {
            Flip(true);
            _animator.SetFloat(Words.AnimatorSpeedHash, Mathf.Abs(_horizontalMove));
            ApplyVelocityRigidBody(_horizontalMove);
        }

        public void Right()
        {
            Flip(false);
            _animator.SetFloat(Words.AnimatorSpeedHash, Mathf.Abs(_horizontalMove));
            ApplyVelocityRigidBody(_horizontalMove);
        }

        private void Flip(bool flipX)
        {
            _spriteRenderer.flipX = flipX;
        }

        private void ApplyVelocityRigidBody(float horizontalMove)
        {
            Vector2 targetVelocity = new Vector2(horizontalMove * 10f, _rigidbody.velocity.y);
            _rigidbody.velocity = Vector2.SmoothDamp(_rigidbody.velocity, targetVelocity, ref _velocityVector, _movementSmoothing);
        }

        /// <summary>
        /// Seta a velocidade para o RB.
        /// </summary>
        /// <param name="x">Axis Raw value</param>
        public void Velocity(float x)
        {
            _horizontalMove = x * _runSpeed;
        }

        public void Idle()
        {
            ApplyVelocityRigidBody(0);
            _animator.SetFloat(Words.AnimatorSpeedHash, 0);
        }
    }
}