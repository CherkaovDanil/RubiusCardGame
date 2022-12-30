using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CardGame.Card
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private RawImage artImage;
        [SerializeField] private Image currentImage;
        [SerializeField] private TextMeshProUGUI heroName;
        [SerializeField] private TextMeshProUGUI heroDiscription;

        private Sprite _backCardSprite;
        private Sprite _frontCardSprite;
        private Sprite _currentCardSide;
        
        [Inject]
        private void Construct(CardViewProtocol protocol)
        {
            _currentCardSide = protocol.BackSprite;
            _backCardSprite = protocol.BackSprite;
            _frontCardSprite = protocol.FrontSprite;
            heroName.text = protocol.Name;
            heroDiscription.text = protocol.Discription;
            
        }    
    }
}