using Model.Interface.Action;
using Model.Interface.Entity;

namespace Model.Concrete.Action
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