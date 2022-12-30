using UnityEngine;

namespace CardGame.Card
{
    [CreateAssetMenu(fileName = "DownloadCardsSettings", menuName = "Cards/DownloadCardsSettings", order = 2)]
    public class DownloadCardsSettings : ScriptableObject
    {
        public string URl => url;
        public int CountCard => countCard;

        [SerializeField] private string url;
        [SerializeField] private int countCard;
    }
}