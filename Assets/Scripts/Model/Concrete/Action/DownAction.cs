using Model.Interface.Action;
using Model.Interface.Entity;

namespace Model.Concrete.Action
{
    public class DownAction : ICommandAction
    {
        private IMoveableEntity _moveableEntity;
        public DownAction(IMoveableEntity entity)
        {
            this._moveableEntity = entity;
        }

        public void Action()
        {
            this._moveableEntity.Down();
        }
    }
}