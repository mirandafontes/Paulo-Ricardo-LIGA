using UnityEngine;

namespace Gawr.Model.Data
{
    /// <summary>
    /// Contém os dados referentes a cena.
    /// Utilizando scriptable objects é mais fácil para
    /// expandir e alterar o código ou ajustar alguma fase.
    /// </summary>
    [CreateAssetMenu(fileName = "Scene Data", menuName = "Scriptable Objects/Scene Data Object", order = 1)]
    public class SceneData : ScriptableObject
    {
        [Tooltip("Segundos")]
        public int TotalTime;
        [Tooltip("Números de cogumelos para dar spawn")]
        public int GoodMushroomsSpawn;
        [Tooltip("Números de cogumelos para dar spawn")]
        public int BadMushroomsSpawn;
        public int PointsPerGoodMushroom;
        public int PointsToWin;
    }
}
