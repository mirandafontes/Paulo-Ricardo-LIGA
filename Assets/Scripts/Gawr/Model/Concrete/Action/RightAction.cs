using Gawr.Model.Interface.Action;
using Gawr.Model.Interface.Entity;

namespace Gawr.Model.Concrete.Action
{
    public class RightAction : ICommandAction
    {
        private IMoveableEntity _moveableEntity;
        public RightAction(IMoveableEntity entity)
        {
            this._moveableEntity = entity;
        }

        public void Action()
        {
            this._moveableEntity.Right();
        }
    }
}