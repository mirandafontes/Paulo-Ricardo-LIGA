using UnityEngine;

namespace Gawr.Misc
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] private Transform _groundTransform;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _circleRadius;

        public bool IsGrounded()
        {
            //Isso talvez traga uma consequencia como: Dinossauro encostado lateralmente na parede, permitir jump
            //return Physics2D.IsTouchingLayers(_collider, _groundLayer);
            
            return Physics2D.OverlapCircle(_groundTransform.position, _circleRadius, _groundLayer);
        }
    }
}

