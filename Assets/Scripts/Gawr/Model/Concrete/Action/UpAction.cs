using Gawr.Model.Interface.Action;
using Gawr.Model.Interface.Entity;

namespace Gawr.Model.Concrete.Action
{
    public class UpAction : ICommandAction
    {
        private IMoveableEntity _moveableEntity;
        public UpAction(IMoveableEntity entity)
        {
            this._moveableEntity = entity;
        }

        public void Action()
        {
            this._moveableEntity.Up();
        }
    }
}