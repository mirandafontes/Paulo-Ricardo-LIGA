using Model.Interface.Action;
using Model.Interface.Entity;

namespace Model.Concrete.Action
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