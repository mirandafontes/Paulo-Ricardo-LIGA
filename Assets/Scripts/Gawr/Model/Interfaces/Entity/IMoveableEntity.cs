namespace Gawr.Model.Interface.Entity
{
    /// <summary>
    /// Interface para definir movimentação para as entidades.
    /// Cada um desses será representado como um Command concreto.
    /// </summary>
    public interface IMoveableEntity
    {
        void Up();
        void Down();
        void Left();
        void Right();
        void Velocity(float x);
        void Idle();
    }
}
