using Gawr.Model.Interface.Action;
using Gawr.Model.Interface.Entity;

namespace Gawr.Model.Concrete.Action
{
    public class DieAction : ICommandAction
    {
        private IMoveableEntity _moveableEntity;
        public DieAction(IMoveableEntity entity)
        {
            this._moveableEntity = entity;
        }

        public void Action()
        {
            this._moveableEntity.Die();
        }
    }
}