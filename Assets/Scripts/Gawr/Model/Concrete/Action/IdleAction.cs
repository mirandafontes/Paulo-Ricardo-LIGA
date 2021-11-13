using Gawr.Model.Interface.Action;
using Gawr.Model.Interface.Entity;

namespace Gawr.Model.Concrete.Action
{
    public class IdleAction : ICommandAction
    {
        private IMoveableEntity _moveableEntity;
        public IdleAction(IMoveableEntity entity)
        {
            this._moveableEntity = entity;
        }

        public void Action()
        {
            this._moveableEntity.Idle();
        }
    }
}