namespace Gawr.Model.Interface.Rulers
{
    /// <summary>
    /// Classe que representa contadores de tempo.
    /// Utilizar segundos de preferência.
    /// </summary>
    public interface ITimer
    {
        /// <summary>
        /// Iniciar/Resumir contagem de tempo.
        /// </summary>
        void StartTimer();
        /// <summary>
        /// Pausar contagem de tempo.
        /// </summary>
        void StopTimer();
        /// <summary>
        /// Acabou o tempo.
        /// </summary>
        void TimeOut();
        /// <summary>
        /// Contagem de tempo atual.
        /// </summary>
        /// <returns>Utilizar segundos de preferência.</returns>
        int CurrentTime();
    }
}
