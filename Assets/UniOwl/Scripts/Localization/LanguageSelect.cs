using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace UniOwl.Localization
{
    public class LanguageSelect : MonoBehaviour
    {
        private AssetReference currentLanguage;

        [SerializeField]
        private AssetReference[] languages;

        public void SetLanguage(int index)
        {
            StartCoroutine(SetLanguage_Internal(index));
        }

        private IEnumerator SetLanguage_Internal(int index)
        {
            currentLanguage?.ReleaseAsset();

            var handle = languages[index].LoadAssetAsync<Locale>();

            yield return handle;

            LocalizationSettings.SelectedLocale = handle.Result;
            currentLanguage = languages[index];
        }

        private async Task SetLanguageAsync(int index)
        {
            currentLanguage?.ReleaseAsset();

            var handle = languages[index].LoadAssetAsync<Locale>();

            await handle.Task;

            LocalizationSettings.SelectedLocale = handle.Result;
            currentLanguage = languages[index];
        }
    }
}
