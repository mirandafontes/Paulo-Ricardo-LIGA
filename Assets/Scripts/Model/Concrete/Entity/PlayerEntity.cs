using Model.Interface.Entity;
using UnityEngine;

namespace Model.Concrete.Entity
{
    /// <summary>
    /// Representa o player e os inimigos (Entities). Ponte entre o command e o monobehaviour.
    /// Receiver.
    /// </summary>
    public class PlayerEntity : MonoBehaviour, IMoveableEntity
    {
        public void Up()
        {

        }

        public void Down()
        {

        }

        public void Left()
        {

        }

        public void Right()
        {

        }
    }
}