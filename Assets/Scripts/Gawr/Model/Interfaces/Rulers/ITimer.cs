namespace Gawr.Model.Interface.Rulers
{
    /// <summary>
    /// Classe que representa contadores de tempo.
    /// Utilizar segundos de preferência.
    /// </summary>
    public interface ITimer
    {
        void StartTimer();
        void StopTimer();
        void TimeOut();
        int CurrentTime();
    }
}
