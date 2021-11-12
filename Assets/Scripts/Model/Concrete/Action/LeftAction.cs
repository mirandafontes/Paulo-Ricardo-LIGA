using Model.Interface.Action;
using Model.Interface.Entity;

namespace Model.Concrete.Action
{
    public class LeftAction : ICommandAction
    {
        private IMoveableEntity _moveableEntity;
        public LeftAction(IMoveableEntity entity)
        {
            this._moveableEntity = entity;
        }

        public void Action()
        {
            this._moveableEntity.Left();
        }
    }
}