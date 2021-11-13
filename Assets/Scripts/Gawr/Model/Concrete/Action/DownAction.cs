using Gawr.Model.Interface.Action;
using Gawr.Model.Interface.Entity;

namespace Gawr.Model.Concrete.Action
{
    //Infelizmente, não temos a opção de abaixar no joguinho
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