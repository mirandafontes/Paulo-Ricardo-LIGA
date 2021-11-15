using Gawr.Model.Concrete.Action;
using Gawr.Model.Interface.Action;
using Gawr.Model.Interface.Entity;
using UnityEngine;

namespace Gawr.Invoker
{
    public class ControllerHandler : MonoBehaviour
    {
        [Header("Componentes")]
        [SerializeField]
        [Tooltip("Utilizado para extrair a interface daqui")]
        private GameObject _playerEntityGO;
        private IMoveableEntity _playerEntity;
        private ICommandAction _rightCommand, _leftCommand, _upCommand, _idleCommand;
        private float _horizontalAxisRaw;
        private bool _shouldJump;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (_playerEntityGO != null)
            {
                _playerEntity = _playerEntityGO.GetComponent<IMoveableEntity>();
            }

            if (_playerEntity != null)
            {
                _rightCommand = new RightAction(_playerEntity);
                _leftCommand = new LeftAction(_playerEntity);
                _upCommand = new UpAction(_playerEntity);
                _idleCommand = new IdleAction(_playerEntity);
            }

            _shouldJump = false;
            _horizontalAxisRaw = 0;
        }

#if UNITY_EDITOR
        private void Update()
        {
            _horizontalAxisRaw = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump"))
            {
                _shouldJump = true;
            }
        }
#endif

        public void SetHorizontalAxis(float horizontalAxisRaw)
        {
            _horizontalAxisRaw = Mathf.Clamp(horizontalAxisRaw, -1f, +1f);
        }

        public void Jump()
        {
            _shouldJump = true;
        }


        //Como estamos utilizando RigidBody
        private void FixedUpdate()
        {
            _playerEntity?.Velocity(_horizontalAxisRaw * Time.fixedDeltaTime);

            //Direita
            if (_horizontalAxisRaw > 0)
            {
                _rightCommand?.Action();
            }
            //Esquerda
            else if (_horizontalAxisRaw < 0)
            {
                _leftCommand?.Action();
            }
            else
            {
                _idleCommand?.Action();
            }

            if (_shouldJump)
            {
                _upCommand?.Action();
                _shouldJump = false;
            }
        }
    }
}