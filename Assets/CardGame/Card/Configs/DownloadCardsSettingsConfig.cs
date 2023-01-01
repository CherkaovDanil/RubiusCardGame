using UnityEngine;

namespace CardGame.Card.Configs
{
    [CreateAssetMenu(fileName = "DownloadCardsSettings", menuName = "Cards/DownloadCardsSettings", order = 2)]
    public class DownloadCardsSettingsConfig : ScriptableObject
    {
        public string URl => url;

        [SerializeField] private string url;
    }
}