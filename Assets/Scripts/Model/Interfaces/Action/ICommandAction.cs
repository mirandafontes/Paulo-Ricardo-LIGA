namespace Model.Interface.Action
{
    /// <summary>
    /// Command para ações genéricas. A construção de uma lista pré-definida de commands
    /// permite a criação rápida e fácil de uma IA simples.
    /// </summary>
    public interface ICommandAction
    {
        void Action();
    }
}