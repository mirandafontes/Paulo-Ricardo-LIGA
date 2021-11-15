using Gawr.Model.Data;
using Gawr.Model.Ruler;
using UnityEngine;
using UnityEngine.UI;

namespace Gawr.UI.Misc
{
    public class WritePosGameData : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private SceneTimer _sceneTimer;
        [SerializeField] private PlayerContainerData _playerContainer;

        [Header("UI")]
        [SerializeField] private Text _timeText;
        [SerializeField] private Text _pointsText;
        [SerializeField] private Text _mushroomText;

        public void WriteValues()
        {
            _timeText.text = _sceneTimer.CurrentTime().ToString() + "s";
            _pointsText.text = _playerContainer.CurrentPoints.ToString();
            _mushroomText.text = _playerContainer.GoodMushroomsCounter.ToString();
        }

    }
}