namespace Gawr.Model.Data
{
    /// <summary>
    /// Contém os dados referentes a sessão do player na cena.
    /// Ou seja, total de pontos e cogumelos agora na cena.
    /// </summary>
    [System.Serializable]
    public class PlayerData
    {
        public int CurrentPoints { get; private set; }
        public int MushroomsCounter { get; private set; }
        public bool IsPlayerAlive { get; set; }

        public void AddPoints(int points)
        {
            if (points < 0)
            {
                return;
            }

            CurrentPoints += points;
        }

        public void RemovePoints(int points)
        {
            if (points > 0)
            {
                return;
            }

            CurrentPoints += points;
        }

        public void ResetPoints()
        {
            CurrentPoints = 0;
        }

        public void AddMushrooms(int mushrooms)
        {
            if (mushrooms < 0)
            {
                return;
            }

            MushroomsCounter += mushrooms;
        }

        public void RemoveMushrooms(int mushrooms)
        {
            if (mushrooms > 0)
            {
                return;
            }

            MushroomsCounter += mushrooms;
        }

        public void ResetMushrooms()
        {
            MushroomsCounter = 0;
        }
    }
}
