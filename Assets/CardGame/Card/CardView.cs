using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CardGame.Card
{
    public class CardView : MonoBehaviour
    {
        public CardSide CardSide => _cardSide;
        
        [SerializeField] private RawImage artImage;
        [SerializeField] private Image currentImage;
        [SerializeField] private GameObject content;
        [SerializeField] private TextMeshProUGUI heroName;
        [SerializeField] private TextMeshProUGUI heroDiscription;

        private Sprite _backCardSprite;
        private Sprite _frontCardSprite;
        private Sprite _currentImage;
        private CardSide _cardSide = CardSide.Back;
        
        [Inject]
        private void Construct(CardViewProtocol protocol)
        {
            _currentImage = protocol.BackSprite;
            _backCardSprite = protocol.BackSprite;
            _frontCardSprite = protocol.FrontSprite;
            heroName.text = protocol.Name;
            heroDiscription.text = protocol.Discription;
            transform.SetParent(protocol.Transform);
        }

        public void SetCardSide(CardSide cardSide)
        {
            _cardSide = cardSide;
            content.SetActive(cardSide == CardSide.Front);
            currentImage.sprite = cardSide == CardSide.Back ? _backCardSprite : _frontCardSprite;
        }

        public void SetArt(Texture2D texture2D)
        {
            artImage.texture = null;
            artImage.texture = texture2D;
        }
    }
}