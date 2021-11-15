namespace Gawr.Model.Data
{
    /// <summary>
    /// Contém os dados referentes a sessão do player na cena.
    /// Ou seja, total de pontos e cogumelos agora na cena.
    /// A intenção é separar os dados da lógica, além de
    /// criar um denominador comum para todos que desejem
    /// trabalhar com os dados.
    /// </summary>
    [System.Serializable]
    public class PlayerData
    {
        public int CurrentPoints { get; private set; }
        public int GoodMushroomsCounter { get; private set; }
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

            CurrentPoints -= points;
        }

        public void ResetPoints()
        {
            CurrentPoints = 0;
        }

        public void AddGoodMushrooms(int mushrooms)
        {
            if (mushrooms < 0)
            {
                return;
            }

            GoodMushroomsCounter += mushrooms;
        }

        public void RemoveGoodMushrooms(int mushrooms)
        {
            if (mushrooms > 0)
            {
                return;
            }

            GoodMushroomsCounter -= mushrooms;
        }

        public void ResetGoodMushrooms()
        {
            GoodMushroomsCounter = 0;
        }
    }
}
