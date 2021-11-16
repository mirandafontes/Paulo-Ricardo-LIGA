using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Gawr.UI.ADS
{
    public class BannerADS : MonoBehaviour
    {
        [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;
        [SerializeField] private string _gameID = "4453918";
        [SerializeField] private string _adUnitID = "Banner_Android";
        public bool TestMode = true;

        private void Start()
        {
            Advertisement.Initialize(_gameID, TestMode);
            Advertisement.Banner.SetPosition(_bannerPosition);
            StartCoroutine(ShowBannerWhenInitialized());
        }

        private IEnumerator ShowBannerWhenInitialized()
        {
            var wait = new WaitForSeconds(0.2f);

            Advertisement.Load(_adUnitID);

            while (!Advertisement.isInitialized && !Advertisement.IsReady())
            {
                yield return wait;
            }

            Advertisement.Banner.Show(_adUnitID);

            yield return null;
        }

        private void OnDestroy()
        {
            Advertisement.Banner.Hide();
        }

    }
}